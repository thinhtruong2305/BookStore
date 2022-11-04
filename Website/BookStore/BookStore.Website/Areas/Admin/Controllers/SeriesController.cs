using BookStore.Website.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Website.Areas.Admin.Controllers
{
    public class SeriesController : Controller
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
        public IActionResult Create(SeriesViewModel model)
        {

            return View();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(SeriesViewModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(SeriesViewModel model)
        {
            return View();
        }
    }
}
