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
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorRequest, BaseCommandResultWithData<Author>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateAuthorHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Author>> Handle(UpdateAuthorRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Author>();

            try
            {
                var author = database.Authors
                    .Where(a => a.Status != Status.Delete)
                    .FirstOrDefault(a => a.AuthorId == request.AuthorId);

                if(author != null)
                {
                    mapper.Map(request, author);
                    author.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                    database.Update(author);
                    database.SaveChanges();

                    result.Success = true;
                    result.Data = author;
                }
                else
                {
                    result.Message = "Không thể thực hiện. Vui lòng kiểm tra lại id!";
                }
            }
            catch(Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
