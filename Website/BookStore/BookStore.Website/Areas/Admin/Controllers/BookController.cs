using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Queries.Implement;
using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Catalog.Interface;
using BookStore.Logic.Shared.Model;
using BookStore.Utils.Extension;
using BookStore.Utils.Global;
using BookStore.Website.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ITagQueries tagQueries;
        private readonly ICategoryQueries categoryQueries;
        private readonly IPublisherQueries publisherQueries;
        private readonly IAuthorQueries authorQueries;
        private readonly IBookImageQueries bookImageQueries;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly AppDatabase database;
        public const string BOOKIMAGES = "bookimages";
        public const string PUBLISHERS = "publishers";
        public const string TAGS = "tags";
        public const string AUTHORS = "authors";

        public BookController(IBookQueries bookQueries,
            ITagQueries tagQueries,
            ICategoryQueries categoryQueries,
            IPublisherQueries publisherQueries,
            IAuthorQueries authorQueries,
            IBookImageQueries bookImageQueries,
            IMediator mediator,
            IMapper mapper,
            AppDatabase database)
        {
            this.bookQueries = bookQueries;
            this.tagQueries = tagQueries;
            this.categoryQueries = categoryQueries;
            this.publisherQueries = publisherQueries;
            this.authorQueries = authorQueries;
            this.bookImageQueries = bookImageQueries;
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

        public IActionResult Trash()
        {
            var model = new List<BookSummaryModel>();
            model = bookQueries.GetAllDelete();
            return View(model);
        }

        public IActionResult ListTrash()
        {
            var model = new List<BookSummaryModel>();
            model = bookQueries.GetAllDelete();
            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> ReTrash(int id)
        {
            var command = new RecoveryBookRequest()
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
        public IActionResult Create()
        {
            BookViewModel model = new BookViewModel();
            if (categoryQueries.GetAll().Count > 0)
            {
                model.Categories = categoryQueries.GetAll();
            }
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
                var tagInfoResult = new BaseCommandResultWithData<TagInfo>();
                SetContextToModel(model, tagsView, publishersView, authorsView, bookImagesView);

                await CreateTagAndAddToListAsync(tagsView, listTag, tagResult);
                await CreateAuthorAndAddToListAsync(authorsView, listAuthor, authorResult);
                await CreatePublisherAndAddToListAsync(publishersView, listPublisher, publisherResult);
                await CreateBookImageAndAddToListAsync(bookImagesView, listBookImage, bookImageResult);

                seriesResult = await mediator.Send(model.SeriesViewModel.ToCreateCommand());
                if (seriesResult.Success)
                {
                    infoResult = await mediator.Send(model.InfoViewModel.ToCreateCommand(seriesResult.Data));
                }
                var edition = bookQueries.GetBookByISBN(model.EditionViewModel.ISBN);
                if (edition != null)
                {
                    model.EditionViewModel.ISBN = " ";
                    return View(model);
                }
                editionResult = await mediator.Send(model.EditionViewModel.ToCreateCommand());
                if (editionResult.Success && infoResult.Success && listBookImage.Count > 0)
                {
                    string? decodedHtml = System.Net.WebUtility.HtmlDecode(model.Decription);
                    model.Decription = decodedHtml;
                    bookResult = await mediator.Send(model.ToCreateCommand(infoResult.Data, editionResult.Data, listBookImage));
                }

                if(infoResult.Success && listTag.Count > 0)
                {
                    foreach (var item in listTag)
                    {
                        tagInfoResult = await mediator.Send(new AddTagAndInfoToTagInfoRequest
                        {
                            Tag = item,
                            Info = infoResult.Data
                        });
                    }
                }

                if(bookResult.Success && listAuthor.Count > 0)
                {
                    foreach (var item in listAuthor)
                    {
                        authorBookResult = await mediator.Send(new AddAuthorAndBookToAuthorBookRequest
                        {
                            Author = item,
                            Book = bookResult.Data
                        });
                    }
                }

                if (editionResult.Success && listPublisher.Count > 0)
                {
                    foreach (var item in listPublisher)
                    {
                        editionPublisherResult = await mediator.Send(new AddEditionAndPublisherToEditionPubliserRequest
                        {
                            Edition = editionResult.Data,
                            Publisher = item
                        });
                    }

                }
                database.SaveChanges();
                ClearSessionCreatBook();
                return RedirectToAction("Index", "Book");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View("Create", model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var session = HttpContext.Session;

            var book = new BookDetailModel();
            book = bookQueries.GetDetail(id);
            var model = mapper.Map<BookViewModel>(book);

            var tagsView = mapper.Map<List<TagViewModel>>(tagQueries.GetListTagDetailByInfoId(book.InfoId));
            string tags = JsonConvert.SerializeObject(tagsView);
            session.SetString(TAGS, tags);

            var authorView = mapper.Map<List<AuthorViewModel>>(authorQueries.GetAuthorDetailModelByBookId(book.BookId));
            string authors = JsonConvert.SerializeObject(authorView);
            session.SetString(AUTHORS, authors);

            var bookImageView = mapper.Map<List<BookImageViewModel>>(bookImageQueries.GetListBookImageByBookId(book.BookId));
            string bookImages = JsonConvert.SerializeObject(bookImageView);
            session.SetString(BOOKIMAGES, bookImages);

            var publisherView = mapper.Map<List<PublisherViewModel>>(publisherQueries.GetListPublisherDetailByEditionId(book.Edition.EditionId));
            string publishers = JsonConvert.SerializeObject(publisherView);
            session.SetString(PUBLISHERS, publishers);
            if (categoryQueries.GetAll().Count > 0)
            {
                model.Categories = categoryQueries.GetAll();
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetFromContext(HttpContext);
                model.InfoViewModel.SetFromContext(HttpContext);
                model.EditionViewModel.SetFromContext(HttpContext);
                model.SeriesViewModel.SetFromContext(HttpContext);
                //Command result
                var bookResult = new BaseCommandResultWithData<Book>();
                //Không dùng list
                var infoResult = new BaseCommandResultWithData<Info>();
                var editionResult = new BaseCommandResultWithData<Edition>();
                var seriesResult = new BaseCommandResultWithData<Series>();

                seriesResult = await mediator.Send(model.SeriesViewModel.ToUpdateCommand());
                if (seriesResult.Success)
                {
                    infoResult = await mediator.Send(model.InfoViewModel.ToUpdateCommand(seriesResult.Data.SeriesId));
                }
                editionResult = await mediator.Send(model.EditionViewModel.ToUpdateCommand(model.BookId));
                if (editionResult.Success && infoResult.Success)
                {
                    string? decodedHtml = System.Net.WebUtility.HtmlDecode(model.Decription);
                    model.Decription = decodedHtml;
                    bookResult = await mediator.Send(model.ToUpdateCommand(infoResult.Data.InfoId, model.CategoryId));
                }
                database.SaveChanges();
                ClearSessionCreatBook();
                return RedirectToAction("Index", "Book");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }
            return View("Create", model);
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
        public async Task CreateTagAndAddToListAsync(List<TagViewModel> tagsView, List<Tag> listTag, BaseCommandResultWithData<Tag> tagResult)
        {
            if (tagsView != null)
            {
                if (tagsView.Count > 0)
                {
                    foreach (var item in tagsView)
                    {
                        var tag = tagQueries.GetTagByName(item.TagName);
                        if (tag == null)
                        {
                            tagResult = await mediator.Send(item.ToCreateCommand());
                            if (tagResult.Success)
                            {
                                listTag.Add(tagResult.Data);
                            }
                        }
                        else
                        {
                            listTag.Add(tag);
                        }
                    }
                }
            }
        }

        public async Task CreateAuthorAndAddToListAsync(List<AuthorViewModel> authorsView, List<Author> listAuthor, BaseCommandResultWithData<Author> authorResult)
        {
            if (authorsView != null)
            {
                if (authorsView.Count > 0)
                {
                    foreach (var item in authorsView)
                    {
                        var author = authorQueries.GetAuthorByName(item.FirstName, item.LastName);
                        if (author == null)
                        {
                            authorResult = await mediator.Send(item.ToCreateCommand());
                            if (authorResult.Success)
                            {
                                listAuthor.Add(authorResult.Data);
                            }
                        }
                        else
                        {
                            listAuthor.Add(author);
                        }
                    }
                }
            }
        }

        public async Task CreatePublisherAndAddToListAsync(List<PublisherViewModel> publishersView, List<Publisher> listPublisher, BaseCommandResultWithData<Publisher> publisherResult)
        {
            if (publishersView != null)
            {
                if (publishersView.Count > 0)
                {

                    foreach (var item in publishersView)
                    {
                        var publisher = publisherQueries.GetPublisherByPulishingHouse(item.PulishingHouse);
                        if (publisher == null)
                        {
                            publisherResult = await mediator.Send(item.ToCreateCommand());
                            if (publisherResult.Success)
                            {
                                listPublisher.Add(publisherResult.Data);
                            }
                        }
                        else
                        {
                            listPublisher.Add(publisher);
                        }
                    }
                }
            }
        }

        public async Task CreateBookImageAndAddToListAsync(List<BookImageViewModel> bookImagesView, List<BookImage> listBookImage, BaseCommandResultWithData<BookImage> bookImageResult)
        {
            if (bookImagesView != null)
            {
                if (bookImagesView.Count > 0)
                {
                    foreach (var item in bookImagesView)
                    {
                        bookImageResult = await mediator.Send(item.ToCreateCommand());
                        if (bookImageResult.Success)
                        {
                            listBookImage.Add(bookImageResult.Data);
                        }
                    }
                }
            }
        }
        public void ClearSessionCreatBook()
        {
            var session = HttpContext.Session;
            session.SetString(BOOKIMAGES, "");
            session.SetString(TAGS, "");
            session.SetString(PUBLISHERS, "");
            session.SetString(AUTHORS, "");
        }
    }
}
