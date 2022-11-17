using System.ComponentModel.DataAnnotations;

namespace BookStore.Website.Areas.Identity.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
