using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using BookStore.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class AuthorViewModel : BaseViewModel
    {
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập họ và tên lót")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Bạn phải nhập từ {1} đến {0}")]
        [Display(Name = "Họ và tên lót")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên của tác giả")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Bạn phải nhập từ {1} đến {0}")]
        [Display(Name = "Tên")]
        public string LastName { get; set; }

        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBirth { get; set; }

        [StringLength(20, ErrorMessage = "Bạn phải nhập được đến {0}")]
        [Display(Name = "Nơi ở")]
        public string? CountryOfResidence { get; set; }

        [StringLength(60, ErrorMessage = "Bạn phải nhập được đến {0}")]
        [Display(Name = "Từ khóa")]
        public string? Keyword { get; set; }

        [Display(Name = "Mô tả")]
        public string? Decription { get; set; }

        public CreateAuthorRequest ToCreateCommand()
        {
            return new CreateAuthorRequest
            {
                FirstName = FirstName,
                LastName = LastName,
                CountryOfResidence = CountryOfResidence,
                DateOfBirth = DateOfBirth,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(FirstName + " " + LastName),
                Status = Common.Shared.Model.Status.Active,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }

        public UpdateAuthorRequest ToUpdateCommand()
        {
            return new UpdateAuthorRequest
            {
                FirstName = FirstName,
                LastName = LastName,
                CountryOfResidence = CountryOfResidence,
                DateOfBirth = DateOfBirth,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(FirstName + " " + LastName),
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
    }
}
