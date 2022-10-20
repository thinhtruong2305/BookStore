using Microsoft.AspNetCore.Mvc;

namespace BookStore.Website.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
