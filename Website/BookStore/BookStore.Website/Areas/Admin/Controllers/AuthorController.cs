using BookStore.DAL.Entities;
using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Model;
using BookStore.Website.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorQueries authorQueries;
        private readonly IMediator mediator;
        public const string AUTHORS = "authors";

        public AuthorController(IAuthorQueries authorQueries,
            IMediator mediator)
        {
            this.authorQueries = authorQueries;
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            var model = new List<AuthorSummaryModel>();
            model = authorQueries.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AuthorViewModel model)
        {

            return View();
        }

        [HttpGet]
        public IActionResult AddAuthorToSession()
        {
            AuthorViewModel model = new AuthorViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddAuthorToSession([FromForm] AuthorViewModel model)
        {
            var session = HttpContext.Session;
            List<AuthorViewModel> list = new List<AuthorViewModel>();

            string? authorGet = session.GetString(AUTHORS);
            if (authorGet != null)
            {
                List<AuthorViewModel>? listGet = JsonConvert.DeserializeObject<List<AuthorViewModel>>(authorGet);
                if (listGet != null)
                {
                    list = listGet;
                }
            }
            list.Add(model);
            string authors = JsonConvert.SerializeObject(list);
            session.SetString(AUTHORS, authors);
            return View("~/Areas/Admin/Views/Book/Create.cshtml");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(AuthorViewModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(AuthorViewModel model)
        {
            return View();
        }
    }
}
