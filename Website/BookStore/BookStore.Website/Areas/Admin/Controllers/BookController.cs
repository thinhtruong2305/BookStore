using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Catalog.Interface;
using BookStore.Logic.Shared.Model;
using BookStore.Utils.Extension;
using BookStore.Utils.Global;
using BookStore.Website.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Data;
using System.Globalization;
using System.Security.Claims;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private readonly IBookQueries bookQueries;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly AppDatabase database;
        public const string BOOKIMAGES = "bookimages";
        public const string PUBLISHERS = "publishers";
        public const string TAGS = "tags";
        public const string AUTHORS = "authors";

        public BookController(IBookQueries bookQueries, 
            IMediator mediator,
            IMapper mapper,
            AppDatabase database)
        {
            this.bookQueries = bookQueries;
            this.mediator = mediator;
            this.mapper = mapper;
            this.database = database;
        }
        public IActionResult Index()
        {
            var model = new List<BookSummaryModel>();
            model = bookQueries.GetAll();
            return View(model);
        }
        public IActionResult List()
        {
            var model = new List<BookSummaryModel>();
            model = bookQueries.GetAll();
            return PartialView(model);
        }

        public IActionResult Trash()
        {
            var model = new List<BookSummaryModel>();
            model = bookQueries.GetAllDelete();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> StatusAsync(int id)
        {
            var command = new ChangeBookStatusRequest()
            {
                Id = id,
                RequestId = HttpContext.Connection?.Id,
                IpAddress = HttpContext.Connection?.RemoteIpAddress?.ToString(),
                UserName = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value
            };
            var result = await mediator.Send(command);
            return Json(new { success = result.Success, message = result.Message });
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var model = new BookDetailModel();
            model = bookQueries.GetDetail(id);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            BookViewModel model = new BookViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] BookViewModel model)
        {
            List<TagViewModel> tagsView = new List<TagViewModel>();
            List<PublisherViewModel> publishersView = new List<PublisherViewModel>();
            List<AuthorViewModel> authorsView = new List<AuthorViewModel>();
            List<BookImageViewModel> bookImagesView = new List<BookImageViewModel>();

            var session = HttpContext.Session;
            string? bookImages = session.GetString(BOOKIMAGES);
            if (bookImages != null)
            {
                bookImagesView = JsonConvert.DeserializeObject<List<BookImageViewModel>>(bookImages);
            }
            string? publishers = session.GetString(PUBLISHERS);
            if (publishers != null)
            {
                publishersView = JsonConvert.DeserializeObject<List<PublisherViewModel>>(publishers);
            }
            string? authors = session.GetString(AUTHORS);
            if (authors != null)
            {
                authorsView = JsonConvert.DeserializeObject<List<AuthorViewModel>>(authors);
            }
            string? tags = session.GetString(TAGS);
            if (tags != null)
            {
                tagsView = JsonConvert.DeserializeObject<List<TagViewModel>>(tags);
            }
            if (ModelState.IsValid)
            {
                List<Tag> listTag = new List<Tag>();
                List<Publisher> listPublisher = new List<Publisher>();
                List<Author> listAuthor = new List<Author>();
                List<BookImage> listBookImage = new List<BookImage>();

                //Command result
                var bookResult = new BaseCommandResultWithData<Book>();
                //Có dùng list
                var authorResult = new BaseCommandResultWithData<Author>();
                var tagResult = new BaseCommandResultWithData<Tag>();
                var publisherResult = new BaseCommandResultWithData<Publisher>();
                var bookImageResult = new BaseCommandResultWithData<BookImage>();
                //Không dùng list
                var infoResult = new BaseCommandResultWithData<Info>();
                var editionResult = new BaseCommandResultWithData<Edition>();
                var seriesResult = new BaseCommandResultWithData<Series>();
                //Liên kết nhiều nhiều
                var authorBookResult = new BaseCommandResultWithData<AuthorBook>();
                var editionPublisherResult = new BaseCommandResultWithData<EditionPublisher>();
                SetContextToModel(model, tagsView, publishersView, authorsView, bookImagesView);

                if(tagsView != null)
                {
                    if(tagsView.Count > 0)
                    {
                        tagsView.ForEach(async t =>
                        {
                            tagResult = await mediator.Send(t.ToCreateCommand());
                            if (tagResult.Success)
                                listTag.Add(tagResult.Data);
                        });
                    }
                }
                if(publishersView != null)
                {
                    if(publishersView.Count > 0)
                    {
                        publishersView.ForEach(async p =>
                        {
                            publisherResult = await mediator.Send(p.ToCreateCommand());
                            if (publisherResult.Success)
                                listPublisher.Add(publisherResult.Data);
                        });
                    }
                }
                if(authorsView != null)
                {
                    if(authorsView.Count > 0)
                    {
                        authorsView.ForEach(async a =>
                        {
                            authorResult = await mediator.Send(a.ToCreateCommand());
                            if (authorResult.Success)
                                listAuthor.Add(authorResult.Data);
                        });
                    }
                }
                if(bookImagesView != null)
                {
                    if(bookImagesView.Count > 0)
                    {
                        bookImagesView.ForEach(async a =>
                        {
                            bookImageResult = await mediator.Send(a.ToCreateCommand());
                            if (bookImageResult.Success)
                                listBookImage.Add(bookImageResult.Data);
                        });
                    }
                }

                seriesResult = await mediator.Send(model.SeriesViewModel.ToCreateCommand());
                if (seriesResult.Success)
                {
                    infoResult = await mediator.Send(model.InfoViewModel.ToCreateCommand(seriesResult.Data, listTag));
                }

                editionResult = await mediator.Send(model.EditionViewModel.ToCreateCommand());
                if(editionResult.Success && infoResult.Success && listBookImage.Count > 0)
                {
                    bookResult = await mediator.Send(model.ToCreateCommand(infoResult.Data, editionResult.Data, listBookImage));
                }

                if(bookResult.Success && listAuthor.Count > 0)
                {
                    listAuthor.ForEach(async a =>
                    {
                        authorBookResult = await mediator.Send(new AddAuthorAndBookToAuthorBookRequest
                        {
                            Author = a,
                            Book = bookResult.Data
                        });
                    });
                }

                if (editionResult.Success && listPublisher.Count > 0)
                {
                    listPublisher.ForEach(async p =>
                    {
                        editionPublisherResult = await mediator.Send(new AddEditionAndPublisherToEditionPubliserRequest
                        {
                            Edition = editionResult.Data,
                            Publisher = p
                        });
                    });

                }
                return RedirectToAction("Index", "Book");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View("Create");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(BookViewModel model)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {            
            var command = new DeleteBookRequest()
            {
                Id = id,
                RequestId = HttpContext.Connection?.Id,
                IpAddress = HttpContext.Connection?.RemoteIpAddress?.ToString(),
                UserName = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value
            };
            var result = await mediator.Send(command);
            return Json(new { success = result.Success, message = result.Message });
        }

        public void SetContextToModel(BookViewModel model, 
            List<TagViewModel> tagsView,
            List<PublisherViewModel> publishersView,
            List<AuthorViewModel> authorsView,
            List<BookImageViewModel> bookImagesView)
        {
            model.SetFromContext(HttpContext);
            authorsView.ForEach(a =>
            {
                a.SetFromContext(HttpContext);
            });
            bookImagesView.ForEach(bi =>
            {
                bi.SetFromContext(HttpContext);
            });
            publishersView.ForEach(p =>
            {
                p.SetFromContext(HttpContext);
            });
            tagsView.ForEach(t =>
            {
                t.SetFromContext(HttpContext);
            });
            model.InfoViewModel.SetFromContext(HttpContext);
            model.EditionViewModel.SetFromContext(HttpContext);
            model.SeriesViewModel.SetFromContext(HttpContext);
        }
    }
}
