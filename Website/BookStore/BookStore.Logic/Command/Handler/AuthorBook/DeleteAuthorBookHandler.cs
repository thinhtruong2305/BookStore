using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class DeleteAuthorBookHandler : IRequestHandler<DeleteAuthorBookRequest, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public DeleteAuthorBookHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResult> Handle(DeleteAuthorBookRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var authorBook = database.AuthorBooks
                    .FirstOrDefault(ab => (ab.BookId == request.BookId) && (ab.AuthorId == request.AuthorId));

                if (authorBook != null)
                {
                    database.Remove(authorBook);
                    database.SaveChanges();

                    result.Success = true;
                }
                else
                {
                    result.Message = "Không thể thực hiện được";
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
