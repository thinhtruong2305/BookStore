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
    public class UpdateTagHandler : IRequestHandler<UpdateTagRequest, BaseCommandResultWithData<Tag>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateTagHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Tag>> Handle(UpdateTagRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Tag>();

            try
            {
                var tag = database.Tags
                    .Where(t => t.Status != Status.Delete)
                    .FirstOrDefault(t => t.TagId == request.TagId);

                if (tag != null)
                {
                    mapper.Map(request, tag);
                    tag.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                    database.Tags.Update(tag);
                    database.SaveChanges();

                    result.Success = true;
                    result.Data = tag;
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
