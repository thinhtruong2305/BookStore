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
    public class CreateBookImageHandler : IRequestHandler<CreateBookImagesRequest, BaseCommandResultWithData<BookImage>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateBookImageHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<BookImage>> Handle(CreateBookImagesRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<BookImage>();

            try
            {
                var bookImage = mapper.Map<BookImage>(request);
                bookImage.SetCreateInfo(request.UserName ?? string.Empty, DateTime.Now);
                database.BookImages.Add(bookImage);
                database.SaveChanges();

                result.Success = true;
                result.Data = bookImage;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
