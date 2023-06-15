using System.ComponentModel.DataAnnotations;

namespace BookStore.Website.Areas.Identity.Models.Manage
{
    public class DisplayRecoveryCodesViewModel
    {
        [Required]
        public IEnumerable<string> Codes { get; set; }  
    }
}
