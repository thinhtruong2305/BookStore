using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Identity.Models.Manage
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}
