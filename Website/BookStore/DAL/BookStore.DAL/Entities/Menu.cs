using BookStore.Common.Shared.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    [Table("Menu")]
    public class Menu : BaseEntity
    {
        public int MenuId { get; set; }
        public int? ParentId { get; set; }

        /*[Required(ErrorMessage = "Bạn phải nhập tên menu")]
        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Tên menu")]*/
        public string MenuName { get; set; }

        /*[RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Từ khóa")]*/
        public string? Keyword { get; set; }

        /*[RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Mô tả")]*/
        public string? Decription { get; set; }

        //[Display(Name = "Liên kết")]
        public string Slug { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
