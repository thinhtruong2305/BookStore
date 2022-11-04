using BookStore.Website.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Website.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel model)
        {

            return View();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(OrderViewModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(OrderViewModel model)
        {
            return View();
        }
    }
}
