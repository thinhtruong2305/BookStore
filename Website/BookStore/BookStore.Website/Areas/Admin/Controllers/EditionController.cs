using Microsoft.AspNetCore.Mvc;

namespace BookStore.Website.Areas.Admin.Controllers
{
    public class EditionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
