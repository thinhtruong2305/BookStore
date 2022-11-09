using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Website.Areas.Admin.Models
{
    [Bind("BookImageId,FilePath,Decription")]
    public class BookImageViewModel : BaseViewModel
    {
        public int BookImageId { get; set; }
        public int BookId { get; set; }
        public string FilePath { get; set; }
        [Display(Name = "Mô tả")]
        public string? Decription { get; set; }
        public string? ReturnUrl { get; set; }

        [BindProperty]
        public IFormFile FileUpLoad { get; set; }

        public CreateBookImageRequest ToCreateCommand()
        {
            return new CreateBookImageRequest
            {
                FilePath = FilePath,
                Decription = Decription
            };
        }
        public CreateBookImageRequest ToCreateCommand(Book Book)
        {
            return new CreateBookImageRequest
            {
                FilePath = FilePath,
                Decription = Decription,
                Book = Book
            };
        }

        public UpdateBookImageRequest ToUpdateCommand()
        {
            return new UpdateBookImageRequest
            {
                FilePath = FilePath,
                Decription = Decription,
            };
        }

        public UpdateBookImageRequest ToUpdateCommand(Book Book)
        {
            return new UpdateBookImageRequest
            {
                FilePath = FilePath,
                Decription = Decription,
                Book = Book
            };
        }
    }
}
