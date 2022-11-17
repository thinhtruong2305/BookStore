using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Shared.Catalog;
using BookStore.Logic.Shared.Catalog.Interface;
using BookStore.Utils.Global;
using MediatR;
using Microsoft.AspNetCore.Server.IISIntegration;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class CreateBookImageHandler : IRequestHandler<CreateBookImageRequest, BaseCommandResultWithData<BookImage>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateBookImageHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<BookImage>> Handle(CreateBookImageRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<BookImage>();

            try
            {
                var bookImage = mapper.Map<BookImage>(request);
                bookImage.SetCreateInfo(request.UserName ?? string.Empty, DateTime.Now);

                result.Success = true;
                result.Data = database.BookImages.Add(bookImage); ;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
