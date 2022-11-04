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
    [Table("Publisher")]
    public class Publisher : BaseEntity
    {
        public int PublisherId { get; set; }

        /*[Required(ErrorMessage = "Bạn phải nhập nhà xuất bản")]
        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Nhà xuất bản")]*/
        public string PulishingHouse { get; set; }

        /*[RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Quốc gia")]*/
        public string? Country { get; set; }

        /*[RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Từ khóa")]*/
        public string? Keyword { get; set; }

        /*[RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Mô tả")]*/
        public string? Decription { get; set; }

        /*[Display(Name = "Liên kết")]*/
        public string Slug { get; set; }
        public List<EditionPublisher> EditionPublishers { get; set; }
    }
}
