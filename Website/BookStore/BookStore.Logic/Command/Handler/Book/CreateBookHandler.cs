using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Shared.Catalog.Interface;
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
    public class CreateBookHandler : IRequestHandler<CreateBookRequest, BaseCommandResultWithData<Book>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateBookHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Book>> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Book>();

            try
            {
                var book = mapper.Map<Book>(request);
                book.SetCreateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                database.Books.Add(book);

                result.Data = book;
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
