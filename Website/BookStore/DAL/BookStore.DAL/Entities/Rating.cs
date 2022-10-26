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
    [Table("Rating")]
    public class Rating : BaseEntity
    {
        public int RatingId { get; set; }
        public string? UserName { get; set; }
        public int BookId { get; set; }
        
        [RegularExpression(@"/^[0-5]+$/", ErrorMessage = "Bạn đánh giá [0-5]")]
        [Display(Name = "Đánh giá")]
        public int? Rate { get; set; }
        public Book Book { get; set; }
    }
}
