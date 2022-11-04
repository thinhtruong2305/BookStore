using BookStore.Logic.Command.Request;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Identity.Models.Account
{
    public class RegisterViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Tên tài khoản", Prompt = "Tên tài khoản")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(100, ErrorMessage = "{0} phải dài từ {2} đến {1} ký tự.", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(100, ErrorMessage = "{0} phải dài từ {2} đến {1} ký tự.", MinimumLength = 2)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu", Prompt = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Lặp lại mật khẩu", Prompt = "Lặp lại mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu lặp lại không chính xác.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phải nhập {0}")]
        [EmailAddress(ErrorMessage = "Sai định dạng Email")]
        [Display(Name = "Email", Prompt = "Email")]
        public string Email { get; set; }
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; } = string.Empty;

        public CreateUserRequest ToCreateCommand()
        {
            return new CreateUserRequest()
            {
                UserName = this.UserName,
                Email = this.Email,
                PhoneNumber = this.PhoneNumber,
                Password = this.Password,
            };
        }
    }
}
