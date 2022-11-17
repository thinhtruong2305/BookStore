using BookStore.Logic.Command.Request;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Identity.Models.Account
{
    public class RegisterViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Họ và tên lót", Prompt = "Tên tài khoản")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(25, ErrorMessage = "{0} phải dài từ {2} đến {1} ký tự.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Tên", Prompt = "Tên tài khoản")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        [StringLength(25, ErrorMessage = "{0} phải dài từ {2} đến {1} ký tự.", MinimumLength = 3)]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Tên tài khoản", Prompt = "Tên tài khoản")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Địa chỉ", Prompt = "Tên tài khoản")]
        [Required(ErrorMessage = "Phải nhập {0}")]
        public string Address { get; set; }

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
        public string? ErrorMessage { get; set; } = string.Empty;

        public CreateUserRequest ToCreateCommand()
        {
            return new CreateUserRequest()
            {
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                DateOfBirth = DateOfBirth,
                UserName = this.UserName,
                Email = this.Email,
                Password = this.Password,
            };
        }
    }
}
