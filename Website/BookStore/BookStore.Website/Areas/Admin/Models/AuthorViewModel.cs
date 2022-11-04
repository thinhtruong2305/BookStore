﻿using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using BookStore.Website.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class AuthorViewModel : BaseViewModel
    {
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập họ và tên lót của tác giả")]
        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Họ và tên lót")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên của tác giả")]
        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Tên")]
        public string LastName { get; set; }

        //[RegularExpression(@"^(?:(?:31(\/)(?:0?[13578]|1[02]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec)))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/)(?:0?2|(?:Feb))\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/)(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Bạn phải nhập dd/MM/yyyy hoặc dd/MMM/yyyy")]
        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBirth { get; set; }

        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Quốc tịch")]
        public string? CountryOfResidence { get; set; }

        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Từ khóa")]
        public string? Keyword { get; set; }

        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Mô tả")]
        public string? Decription { get; set; }

        [Display(Name = "Liên kết")]
        public string Slug { get; set; }

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
                Status = Common.Shared.Model.Status.Active
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
                Slug = AppGlobal.GenerateSlug(FirstName + " " + LastName)
            };
        }
    }
}
