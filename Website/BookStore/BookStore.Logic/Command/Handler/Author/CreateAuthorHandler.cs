using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using MediatR;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class CreateAuthorHandler : IRequestHandler<CreateAuthorRequest, BaseCommandResultWithData<Author>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateAuthorHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public Task<BaseCommandResultWithData<Author>> Handle(CreateAuthorRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Author>();

            try
            {
                var author = mapper.Map<Author>(request);
                author.SetCreateInfo(request.UserName ?? string.Empty, DateTime.Now);
                database.Authors.Add(author);
                database.SaveChanges();

                result.Data = author;
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
