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
    [Table("Book")]
    public class Book : BaseEntity
    {
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
        [Display(Name  = "Mô tả")]
        public string? Decription { get; set; }

        [Display(Name = "Liên kết")]
        public string Slug { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }
        public Info Info { get; set; }
        public Edition Edition { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public List<BookImage> BookImages { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
