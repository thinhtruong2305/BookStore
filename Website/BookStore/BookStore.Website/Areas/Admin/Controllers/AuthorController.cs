using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Queries.Implement;
using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Model;
using BookStore.Utils.Global;
using BookStore.Website.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private readonly IAuthorQueries authorQueries;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly AppDatabase database;
        public const string AUTHORS = "authors";

        public AuthorController(IAuthorQueries authorQueries,
            IMediator mediator,
            IMapper mapper,
            AppDatabase database)
        {
            this.authorQueries = authorQueries;
            this.mediator = mediator;
            this.mapper = mapper;
            this.database = database;
        }

        public IActionResult Index()
        {
            var model = new List<AuthorSummaryModel>();
            model = authorQueries.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult CreateAuthorToBook(string returnUrl, int BookId)
        {
            AuthorViewModel model = new AuthorViewModel();
            model.BookId = BookId;
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authorSave = new Author();
                var author = authorQueries.GetAuthorByName(model.FirstName, model.LastName);
                if (author == null)
                {
                    var ạuthorResult = new BaseCommandResultWithData<Author>();
                    ạuthorResult = await mediator.Send(model.ToCreateCommand());
                    authorSave = ạuthorResult.Data;
                }
                else
                {
                    authorSave = author;
                }
                if (model.BookId != 0)
                {
                    var book = database.Books
                         .Where(i => i.Status != Status.Delete)
                         .FirstOrDefault(i => i.BookId == model.BookId);
                    if (book != null)
                    {
                        var authorBookResult = new BaseCommandResultWithData<AuthorBook>();
                        authorBookResult = await mediator.Send(new AddAuthorAndBookToAuthorBookRequest
                        {
                            Author = authorSave,
                            Book = book
                        });
                    }
                }
            }
            database.SaveChanges();
            return LocalRedirect(model.ReturnUrl);
        }

        [HttpGet]
        public IActionResult AddAuthorToSession(string returnUrl)
        {
            AuthorViewModel model = new AuthorViewModel();
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAuthorToSession(AuthorViewModel model)
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
            }
            return LocalRedirect(model.ReturnUrl);
        }

        public async Task<IActionResult> DeleteAuthorFromBookAsync(string returnUrl, int id, int AuthorId, int BookId)
        {
            var session = HttpContext.Session;
            string? authorGet = session.GetString(AUTHORS);
            if (authorGet != null)
            {
                List<AuthorViewModel>? list = JsonConvert.DeserializeObject<List<AuthorViewModel>>(authorGet);
                if (list != null)
                {
                    var author = authorQueries.GetDetail(AuthorId);
                    if (author == null)
                    {
                        list.RemoveAt(id);
                        string authors = JsonConvert.SerializeObject(list);
                        session.SetString(AUTHORS, authors);
                    }
                    else
                    {
                        var command = new DeleteAuthorBookRequest()
                        {
                            AuthorId = AuthorId,
                            BookId = BookId,
                            RequestId = HttpContext.Connection?.Id,
                            IpAddress = HttpContext.Connection?.RemoteIpAddress?.ToString(),
                            UserName = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value
                        };
                        var result = await mediator.Send(command);
                    }
                }
            }
            return LocalRedirect(returnUrl ?? "/");
        }

        [HttpGet]
        public IActionResult Update(string returnUrl, int id)
        {
            AuthorViewModel model = new AuthorViewModel();
            var session = HttpContext.Session;
            string? tagGet = session.GetString(AUTHORS);
            if (tagGet != null)
            {
                List<AuthorViewModel>? list = JsonConvert.DeserializeObject<List<AuthorViewModel>>(tagGet);
                if (list != null)
                {
                    var author = mapper.Map<AuthorViewModel>(authorQueries.GetDetail(id));
                    if (author == null)
                    {
                        model = list[id];
                        model.ReturnUrl = returnUrl;
                    }
                    else
                    {
                        model = author;
                        model.ReturnUrl = returnUrl;
                    }
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetFromContext(HttpContext);
                var commandResult = new BaseCommandResultWithData<Author>();
                var updateCommand = model.ToUpdateCommand();
                commandResult = await mediator.Send(updateCommand);
            }
            return Redirect(model.ReturnUrl);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return View();
        }
    }
}
