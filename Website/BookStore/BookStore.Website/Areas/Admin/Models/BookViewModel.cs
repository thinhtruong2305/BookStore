using AutoMapper;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
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
        //Database Model
        public int BookId { get; set; }
        public int InfoId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tiêu đề của sách")]
        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Từ khóa")]
        public string? Keyword { get; set; }

        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Mô tả")]
        public string? Decription { get; set; }

        [Display(Name = "Liên kết")]
        public string? Slug { get; set; }

        //ViewModel dùng để hiển thị và trích xuất dữ liệu
/*      public List<PublisherViewModel>? PublishersViewModel { get; set; }
        public List<AuthorViewModel>? AuthorsViewModel { get; set; }
        public List<BookImageViewModel>? BookImagesViewModel { get; set; }
        public List<TagViewModel>? TagsViewModel { get; set; }*/
        public SeriesViewModel SeriesViewModel { get; set; }
        public InfoViewModel InfoViewModel { get; set; }
        public EditionViewModel EditionViewModel { get; set; }

        public CreateBookRequest ToCreateCommand()
        {
            return new CreateBookRequest
            {
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active
            };
        }

        public CreateBookRequest ToCreateCommand(Info info)
        {
            return new CreateBookRequest
            {
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Info = info
            };
        }

        public CreateBookRequest ToCreateCommand(Edition edition)
        {
            return new CreateBookRequest
            {
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Edition = edition
            };
        }
        public CreateBookRequest ToCreateCommand(List<BookImage> bookImages)
        {
            return new CreateBookRequest
            {
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                BookImages = bookImages
            };
        }

        public CreateBookRequest ToCreateCommand(Info info, Edition edition)
        {
            return new CreateBookRequest
            {
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Info = info,
                Edition = edition
            };
        }

        public CreateBookRequest ToCreateCommand(List<BookImage> bookImages, Edition edition)
        {
            return new CreateBookRequest
            {
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                BookImages = bookImages,
                Edition = edition
            };
        }

        public CreateBookRequest ToCreateCommand(List<BookImage> bookImages, Info info)
        {
            return new CreateBookRequest
            {
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                BookImages = bookImages,
                Info = info
            };
        }

        public CreateBookRequest ToCreateCommand(Info info, Edition edition, List<BookImage> bookImages)
        {
            return new CreateBookRequest
            {
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Info = info,
                Edition = edition,
                BookImages = bookImages
            };
        }

        public UpdateBookRequest ToUpdateCommand()
        {
            return new UpdateBookRequest
            {
                BookId = BookId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
            };
        }

        public UpdateBookRequest ToUpdateCommand(Info info)
        {
            return new UpdateBookRequest
            {
                BookId = BookId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Info = info
            };
        }

        public UpdateBookRequest ToUpdateCommand(Edition edition)
        {
            return new UpdateBookRequest
            {
                BookId = BookId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Edition = edition
            };
        }
        public UpdateBookRequest ToUpdateCommand(List<BookImage> bookImages)
        {
            return new UpdateBookRequest
            {
                BookId = BookId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                BookImages = bookImages
            };
        }

        public UpdateBookRequest ToUpdateCommand(Info info, Edition edition)
        {
            return new UpdateBookRequest
            {
                BookId = BookId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Info = info,
                Edition = edition
            };
        }

        public UpdateBookRequest ToUpdateCommand(List<BookImage> bookImages, Edition edition)
        {
            return new UpdateBookRequest
            {
                BookId = BookId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                BookImages = bookImages,
                Edition = edition
            };
        }

        public UpdateBookRequest ToUpdateCommand(List<BookImage> bookImages, Info info)
        {
            return new UpdateBookRequest
            {
                BookId = BookId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                BookImages = bookImages,
                Info = info
            };
        }

        public UpdateBookRequest ToUpdateCommand(Info info, Edition edition, List<BookImage> bookImages)
        {
            return new UpdateBookRequest
            {
                BookId = BookId,
                Title = Title,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Title),
                Status = Common.Shared.Model.Status.Active,
                Info = info,
                Edition = edition,
                BookImages = bookImages
            };
        }
    }
}
