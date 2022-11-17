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
    public class UpdateAuthorBookHandler : IRequestHandler<UpdateAuthorBookRequest,
        BaseCommandResultWithData<AuthorBook>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateAuthorBookHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<AuthorBook>> Handle(UpdateAuthorBookRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<AuthorBook>();

            try
            {
                var authorBook = database.AuthorBooks
                    .FirstOrDefault(ab => (ab.BookId == request.BookId) || (ab.AuthorId == request.AuthorId));

                if (authorBook != null)
                {
                    mapper.Map(request, authorBook);
                    database.Update(authorBook);

                    result.Success = true;
                    result.Data = authorBook;
                }
                else
                {
                    result.Message = "Không thể thực hiện được";
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
