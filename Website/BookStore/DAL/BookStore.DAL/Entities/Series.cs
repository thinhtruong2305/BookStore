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
    [Table("Series")]
    public class Series : BaseEntity
    {
        public int SeriesId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên tag")]
        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Tên tag")]
        public string SeriesName { get; set; }

        [RegularExpression(@"/^[0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [0-9]")]
        [Display(Name = "Đầu sách sắp ra")]
        public int? PlannedVolume { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập từ khóa của sách")]
        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Từ khóa")]
        public string Keyword { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mô tả của sách")]
        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Mô tả")]
        public string Decription { get; set; }

        [Display(Name = "Liên kết")]
        public string Slug { get; set; }

        public Info info { get; set; }
    }
}
