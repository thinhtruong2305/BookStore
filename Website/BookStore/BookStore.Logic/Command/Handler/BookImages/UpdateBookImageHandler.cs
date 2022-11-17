using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Shared.Catalog.Interface;
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
    public class UpdateBookImageHandler : IRequestHandler<UpdateBookImageRequest, BaseCommandResultWithData<BookImage>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateBookImageHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public Task<BaseCommandResultWithData<BookImage>> Handle(UpdateBookImageRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<BookImage>();

            try
            {
                var bookImage = database.BookImages
                    .Where(bi => bi.Status != Status.Delete)
                    .FirstOrDefault(bi => bi.BookImageId == request.BookImageId);

                if(bookImage != null)
                {
                    var bookImageSave = mapper.Map(request, bookImage);
                    bookImageSave.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);

                    result.Success = true;
                    result.Data = database.BookImages.Update(bookImageSave); ;
                }
                else
                {
                    result.Message = "Không tìm thấy hoặc có thể đã bị xóa";
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
