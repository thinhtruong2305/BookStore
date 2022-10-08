using Microsoft.AspNetCore.Mvc;

namespace BookStore.Website.Areas.Identity.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
