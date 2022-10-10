﻿using BookStore.Common.Shared.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    [Table("Tag")]
    public class Tag : BaseEntity
    {
        public int TagId { get; set; }
        public int MenuId { get; set; }

        public int InfoId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên tag")]
        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Tên tag")]
        public string TagName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tiêu đề của sách")]
        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Từ khóa")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tiêu đề của sách")]
        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Mô tả")]
        public string Decription { get; set; }

        [Display(Name = "Liên kết")]
        public string Slug { get; set; }
        public Info Info { get; set; }
        public Menu Menu { get; set; }
    }
}