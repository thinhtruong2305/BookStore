using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class UpdatePublisherHandler : IRequestHandler<UpdatePublisherRequest, BaseCommandResultWithData<Publisher>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdatePublisherHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Publisher>> Handle(UpdatePublisherRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Publisher>();

            try
            {
                var publisher = database.Publishers
                    .Where(p => p.Status != Status.Delete)
                    .FirstOrDefault(p => p.PublisherId == request.PublisherId);

                if (publisher != null)
                {
                    var publisherSave = mapper.Map<Publisher>(request);
                    publisherSave.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                    
                    result.Success = true;
                    result.Data = database.Publishers.Update(publisherSave);
                }
                else
                {
                    result.Message = "Không thể thực hiện. Vui lòng kiểm tra lại id!";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
