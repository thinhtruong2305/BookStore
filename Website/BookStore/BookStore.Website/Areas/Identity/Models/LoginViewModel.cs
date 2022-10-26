using BookStore.Logic.Command.Request;
using NuGet.Protocol.Plugins;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Identity.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Phải nhập {0}")]
        [Display(Name = "Địa chỉ email hoặc tên tài khoản", Prompt = "Địa chỉ email hoặc username")]
        public string UserNameOrEmail { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu", Prompt = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Nhớ thông tin đăng nhập?")]
        public bool RememberMe { get; set; }

        public LoginRequest ToCommand()
        {
            return new LoginRequest()
            {
                UserName = UserNameOrEmail,
                Password = Password,
                RememberPassword = RememberMe
            };
        }

    }
}
