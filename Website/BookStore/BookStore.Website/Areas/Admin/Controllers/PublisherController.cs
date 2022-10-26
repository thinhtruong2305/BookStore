using BookStore.DAL;
using BookStore.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Website.Areas.Admin.Controllers
{
    public class PublisherController : Controller
    {
        private readonly AppDatabase database;

        public PublisherController(AppDatabase database)
        {
            this.database = database;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowPublisherDialog(EditionPublisher editionPublisher = null)
        {
             if(editionPublisher == null)
            {
                return RedirectToAction();
            }
            return View();
        }
        public IActionResult AddPublisherForBook()
        {
            return View();
        }
    }
}
