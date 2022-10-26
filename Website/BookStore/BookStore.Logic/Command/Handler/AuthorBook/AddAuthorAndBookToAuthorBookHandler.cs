﻿using BookStore.Common.Shared.Model;
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
    public class AddAuthorAndBookToAuthorBookHandler : IRequestHandler<AddAuthorAndBookToAuthorBookRequest
        , BaseCommandResultWithData<AuthorBook>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public AddAuthorAndBookToAuthorBookHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public Task<BaseCommandResultWithData<AuthorBook>> Handle(AddAuthorAndBookToAuthorBookRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<AuthorBook>();

            try
            {
                var authorBook = mapper.Map<AuthorBook>(request);
                database.AuthorBooks.Add(authorBook);
                database.SaveChanges();

                result.Data = authorBook;
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