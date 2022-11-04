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
    public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, BaseCommandResultWithData<Book>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateBookHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Book>> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Book>();

            try
            {
                var book = database.Books
                    .Where(b => b.Status != Status.Delete)
                    .FirstOrDefault(b => b.BookId == request.BookId);

                if (book != null)
                {
                    mapper.Map(request, book);
                    book.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                    database.Update(book);

                    result.Success = true;
                    result.Data = book;
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
