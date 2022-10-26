using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using MediatR;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class UpdateEditionPublisherHandler : IRequestHandler<UpdateEditionPublisherRequest, BaseCommandResultWithData<EditionPublisher>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateEditionPublisherHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<EditionPublisher>> Handle(UpdateEditionPublisherRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<EditionPublisher>();

            try
            {
                var editionPublisher = database.EditionPublishers
                    .FirstOrDefault(ep => (ep.EditionId == request.EditionId) || (ep.PublisherId == request.PublisherId));

                if(editionPublisher != null)
                {
                    editionPublisher = mapper.Map<EditionPublisher>(request);
                    database.EditionPublishers.Update(editionPublisher);
                    database.SaveChanges();

                    result.Success = true;
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
