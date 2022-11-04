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

        [Required(ErrorMessage = "Bạn không được để trống")]
        public string FilePath { get; set; }
        public string Decription { get; set; }

        [Required(ErrorMessage = "Chọn một file")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Chọn file upload")]
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

        public UpdateBookImageRequest ToUpdateCommand()
        {
            return new UpdateBookImageRequest
            {
                FilePath = FilePath,
                Decription = Decription,
            };
        }
    }
}
