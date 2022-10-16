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
    [Table("Info")]
    public class Info : BaseEntity
    {
        public int InfoId { get; set; }
        public int SeriesId { get; set; }

        [RegularExpression(@"/^[0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [0-9]")]
        [Display(Name = "Phần trăm giảm giá")]
        public int? DiscountPercent { get; set; }

        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Ngôn ngữ")]
        public string? Language { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập đầu sách")]
        [RegularExpression(@"/^[0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [0-9]")]
        [Display(Name = "Đầu sách")]
        public int VolumeNumber { get; set; }
        public Book Book { get; set; }
        public Series Series { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
