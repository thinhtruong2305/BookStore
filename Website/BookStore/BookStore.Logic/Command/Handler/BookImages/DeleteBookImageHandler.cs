using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
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
    public class DeleteBookImageHandler : IRequestHandler<DeleteBookImageRequest, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public DeleteBookImageHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResult> Handle(DeleteBookImageRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var bookImage = database.BookImages
                    .FirstOrDefault(bi => bi.BookImageId == request.Id);

                if(bookImage != null)
                {
                    bookImage.MarkAsDelete(request.UserName ?? string.Empty, DateTime.Now);
                    database.BookImages.Update(bookImage);
                    database.SaveChanges();

                    result.Success = true;
                }
                else
                {
                    result.Message = $"Không thể tìm thấy hình ảnh hoặc ảnh đã bị xóa";
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
