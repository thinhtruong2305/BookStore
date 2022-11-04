using BookStore.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class RatingViewModel
    {
        public int RatingId { get; set; }
        public string UserName { get; set; }
        public int BookId { get; set; }

        [RegularExpression(@"/^[0-5]+$/", ErrorMessage = "Bạn đánh giá [0-5]")]
        [Display(Name = "Đánh giá")]
        public int Rate { get; set; }
    }
}
