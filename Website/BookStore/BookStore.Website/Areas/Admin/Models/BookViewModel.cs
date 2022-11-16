using AutoMapper;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Shared.Model;
using BookStore.Utils.Global;
using BookStore.Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    [BindProperties]
    public class BookViewModel : BaseViewModel
    {
        //[RegularExpression(@"/^[0-9a-zA-Z_ÀÁÂÃÈÉÊẾÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêếìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\ ]+$/", ErrorMessage = "Bạn phải nhập ký tự và số")]

        //Database Model
        public int BookId { get; set; }
        public int InfoId { get; set; }
        public int CategoryId { get; set; } = 0;

        [Required(ErrorMessage = "Bạn phải nhập tiêu đề của sách")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Bạn phải nhập từ {1} đến {0}")]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [StringLength(60, ErrorMessage = "Bạn phải nhập được đến {0}")]
        [Display(Name = "Từ khóa")]
        public string? Keyword { get; set; }

        [Display(Name = "Mô tả")]
        public string? Decription { get; set; }

        [Display(Name = "Liên kết")]
        public string? Slug { get; set; }

        //ViewModel dùng để hiển thị và trích xuất dữ liệu
        public SeriesViewModel SeriesViewModel { get; set; }
        public InfoViewModel InfoViewModel { get; set; }
        public EditionViewModel EditionViewModel { get; set; }
        public List<CategorySummaryModel>? Categories { get; set; }

        public CreateBookRequest ToCreateCommand()
        {
            return new CreateBookRequest
            {
                CategoryId = CategoryId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }

        public CreateBookRequest ToCreateCommand(Info info)
        {
            return new CreateBookRequest
            {
                CategoryId = CategoryId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Info = info,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }

        public CreateBookRequest ToCreateCommand(Edition edition)
        {
            return new CreateBookRequest
            {
                CategoryId = CategoryId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Edition = edition,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
        public CreateBookRequest ToCreateCommand(List<BookImage> bookImages)
        {
            return new CreateBookRequest
            {
                CategoryId = CategoryId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                BookImages = bookImages,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }

        public CreateBookRequest ToCreateCommand(Info info, Edition edition)
        {
            return new CreateBookRequest
            {
                CategoryId = CategoryId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Info = info,
                Edition = edition,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }

        public CreateBookRequest ToCreateCommand(List<BookImage> bookImages, Edition edition)
        {
            return new CreateBookRequest
            {
                CategoryId = CategoryId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                BookImages = bookImages,
                Edition = edition,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }

        public CreateBookRequest ToCreateCommand(List<BookImage> bookImages, Info info)
        {
            return new CreateBookRequest
            {
                CategoryId = CategoryId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                BookImages = bookImages,
                Info = info,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }

        public CreateBookRequest ToCreateCommand(Info info, Edition edition, List<BookImage> bookImages)
        {
            return new CreateBookRequest
            {
                CategoryId = CategoryId,
                InfoId = info.InfoId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Info = info,
                Edition = edition,
                BookImages = bookImages,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }

        public UpdateBookRequest ToUpdateCommand()
        {
            return new UpdateBookRequest
            {
                BookId = BookId,
                CategoryId = CategoryId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
        public UpdateBookRequest ToUpdateCommand(int InfoId, int CategoryId)
        {
            return new UpdateBookRequest
            {
                BookId = BookId,
                CategoryId = CategoryId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                InfoId = InfoId,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
    }
}
