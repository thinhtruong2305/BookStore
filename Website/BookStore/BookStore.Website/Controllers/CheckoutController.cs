using Microsoft.AspNetCore.Mvc;

namespace BookStore.Website.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
