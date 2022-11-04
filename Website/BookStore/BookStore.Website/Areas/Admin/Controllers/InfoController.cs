using Microsoft.AspNetCore.Mvc;

namespace BookStore.Website.Areas.Admin.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
