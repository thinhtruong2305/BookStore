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
    public class CreateTagHandler : IRequestHandler<CreateTagRequest, BaseCommandResultWithData<Tag>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateTagHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Tag>> Handle(CreateTagRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Tag>();

            try
            {
                var tag = mapper.Map<Tag>(request);
                tag.SetCreateInfo(request.UserName ?? String.Empty, DateTime.Now);
                
                result.Data = database.Tags.Add(tag);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
