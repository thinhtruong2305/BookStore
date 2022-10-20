using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        private readonly IBookQueries bookQueries;

        public BookController(IBookQueries bookQueries)
        {
            this.bookQueries = bookQueries;
        }
        public IActionResult Index()
        {
            var model = new List<BookSummaryModel>();
            model = bookQueries.GetAll();
            return View(model);
        }
        public IActionResult Status(int BookId)
        {

            return View();
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var model = new BookDetailModel();
            model = bookQueries.GetDetail(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Detail(BookDetailModel model)
        {
            return Json(model);
        }
        public IActionResult Delete(int id)
        {
            Console.WriteLine(id);
            return RedirectToAction("Index", "Book", new {Area = "Admin"});
        }
    }
}
