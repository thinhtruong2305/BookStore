using BookStore.DAL.Entities;
using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Model;
using BookStore.Utils.Global;
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
        [ValidateAntiForgeryToken]
        public IActionResult AddAuthorToSession([FromForm] AuthorViewModel model)
        {
            if (ModelState.IsValid)
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
                string? decodedHtml = System.Net.WebUtility.HtmlDecode(model.Decription);
                model.Decription = decodedHtml;
                list.Add(model);
                string authors = JsonConvert.SerializeObject(list);
                session.SetString(AUTHORS, authors);
                return View("~/Areas/Admin/Views/Book/Create.cshtml");
            }

            return Json(new { isValid = false, html = AppGlobal.RenderRazorViewToString(this, "AddAuthorToSession", model) });
        }

        public IActionResult DeleteAuthorFromSession(int id)
        {
            var session = HttpContext.Session;
            string? authorGet = session.GetString(AUTHORS);
            if (authorGet != null)
            {
                List<AuthorViewModel>? list = JsonConvert.DeserializeObject<List<AuthorViewModel>>(authorGet);
                if (list != null)
                {
                    list.RemoveAt(id);
                    string author = JsonConvert.SerializeObject(list);
                    session.SetString(AUTHORS, author);
                }
            }
            return RedirectToAction("Create", "Book");
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
    }
}
