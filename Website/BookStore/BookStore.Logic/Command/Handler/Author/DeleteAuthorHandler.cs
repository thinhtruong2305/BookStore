using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Shared.Interface;
using BookStore.Utils.Global;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorRequest, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public DeleteAuthorHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResult> Handle(DeleteAuthorRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var author = database.Authors
                     .FirstOrDefault(a => a.AuthorId == request.Id);

                if (author != null)
                {
                    author.MarkAsDelete(request.UserName ?? string.Empty, DateTime.Now);
                    database.Update(author);
                    database.SaveChanges();

                    result.Success = true;
                }
                else
                {
                    result.Message = "Không thể thực hiện. Vui lòng kiểm tra lại id!";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return Task.FromResult(result);
        }
    }
}
