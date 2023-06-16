using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Website.Areas.Identity.Models.Manage
{
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        public IList<AuthenticationScheme> OtherLogins { get; set; }
    }
}
