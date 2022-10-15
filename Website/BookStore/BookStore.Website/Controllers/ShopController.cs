using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Website.Controllers
{
    public class ShopController : Controller
    {
        private readonly IBookQueries bookQueries;

        public ShopController(IBookQueries bookQueries)
        {
            this.bookQueries = bookQueries;
        }
        public IActionResult Index()
        {
            var model = new List<BookSummaryClientModel>();
            model = bookQueries.GetAllClient();
            return View(model);
        }
    }
}
