﻿using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using BookStore.Website.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class TagViewModel : BaseViewModel
    {
        public int TagId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên tag")]
        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Tên tag")]
        public string TagName { get; set; }

        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Từ khóa")]
        public string? Keyword { get; set; }

        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Mô tả")]
        public string? Decription { get; set; }

        [Display(Name = "Liên kết")]
        public string Slug { get; set; }

        public CreateTagRequest ToCreateCommand()
        {
            return new CreateTagRequest
            {
                TagName = TagName,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(TagName),
                Status = Common.Shared.Model.Status.Active
            };
        }

        public UpdateTagRequest ToUpdateCommand()
        {
            return new UpdateTagRequest
            {
                TagName = TagName,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(TagName)
            };
        }
    }
}
