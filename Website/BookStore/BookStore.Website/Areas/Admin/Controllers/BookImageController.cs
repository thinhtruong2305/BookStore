using BookStore.DAL.Entities;
using BookStore.Logic.Shared.Catalog.Interface;
using BookStore.Utils.Extension;
using BookStore.Logic.Queries.Interface;
using BookStore.Utils.Global;
using BookStore.Website.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using BookStore.Logic.Queries.Implement;
using BookStore.Logic.Command.Request;
using MediatR;
using System.Security.Claims;
using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookImageController : Controller
    {
        private readonly IFileStorageService storageService;
        private readonly IBookImageQueries bookImageQueries;
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly AppDatabase database;
        public const string BOOKIMAGES = "bookimages";

        public BookImageController(IFileStorageService storageService,
            IBookImageQueries bookImageQueries,
            IMediator mediator,
            IMapper mapper,
            AppDatabase database)
        {
            this.storageService = storageService;
            this.bookImageQueries = bookImageQueries;
            this.mediator = mediator;
            this.mapper = mapper;
            this.database = database;
        }

        [HttpGet]
        public IActionResult CreateBookImageToBook(string returnUrl, int BookId)
        {
            BookImageViewModel model = new BookImageViewModel();
            model.BookId = BookId;
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BookImageViewModel model, string ReturnUrl, int BookId, IFormFile FileUpLoad)
        {
            if (ModelState.IsValid)
            {
                var bookImageSave = new BookImage();
                var bookImage = bookImageQueries.GetBookImageById(model.BookImageId);
                if (bookImage == null)
                {
                    var bookImageResult = new BaseCommandResultWithData<BookImage>();
                    string path = await storageService.SaveFile(FileUpLoad);
                    model.FilePath = path;
                    string decodedHtml = System.Net.WebUtility.HtmlDecode(model.Decription);
                    model.Decription = decodedHtml;
                    bookImageResult = await mediator.Send(model.ToCreateCommand());
                    bookImageSave = bookImageResult.Data;
                }
                bookImageSave = bookImage;
                if (BookId != 0)
                {
                    var book = database.Books
                         .Where(i => i.Status != Status.Delete)
                         .FirstOrDefault(i => i.BookId == model.BookId);
                    if (book != null)
                    {
                        var bookImageResult = new BaseCommandResultWithData<BookImage>();
                        bookImageResult = await mediator.Send(model.ToCreateCommand(book));
                    }
                }
            }
            database.SaveChanges();
            return LocalRedirect(ReturnUrl);
        }

        [HttpGet]
        public IActionResult AddBookImageToSession(string returnUrl)
        {
            BookImageViewModel model = new BookImageViewModel();
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBookImageToSession(BookImageViewModel model, string ReturnUrl, IFormFile FileUpLoad)
        {
            if (FileUpLoad != null)
            {
                var session = HttpContext.Session;
                List<BookImageViewModel> list = new List<BookImageViewModel>();

                string? bookImagesGet = session.GetString(BOOKIMAGES);
                if (bookImagesGet != null)
                {
                    List<BookImageViewModel>? listGet = JsonConvert.DeserializeObject<List<BookImageViewModel>>(bookImagesGet);
                    if (listGet != null)
                    {
                        if (FileUpLoad != null)
                        {
                            list = listGet;
                        }
                    }
                }

                string path = await storageService.SaveFile(FileUpLoad);
                model.FilePath = path;
                string decodedHtml = System.Net.WebUtility.HtmlDecode(model.Decription);
                model.Decription = decodedHtml;
                list.Add(model);
                string bookImages = JsonConvert.SerializeObject(list);
                session.SetString(BOOKIMAGES, bookImages);  
            }
            return LocalRedirect(ReturnUrl ?? "/Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBookImageFromBookAsync(string returnUrl, int id, int BookImageId)
        {
            var session = HttpContext.Session;
            string? bookImagesGet = session.GetString(BOOKIMAGES);
            if (bookImagesGet != null)
            {
                List<BookImageViewModel>? list = JsonConvert.DeserializeObject<List<BookImageViewModel>>(bookImagesGet);
                if (list != null)
                {
                    var bookImage =bookImageQueries.GetBookImageById(BookImageId);

                    if (bookImage == null)
                    {
                        await storageService.DeleteFileAsync(list[id].FilePath);
                        list.RemoveAt(id);
                        string bookImages = JsonConvert.SerializeObject(list);
                        session.SetString(BOOKIMAGES, bookImages);
                    }
                    else
                    {
                        var command = new DeleteBookImageRequest()
                        {
                            Id = id,
                            RequestId = HttpContext.Connection?.Id,
                            IpAddress = HttpContext.Connection?.RemoteIpAddress?.ToString(),
                            UserName = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value
                        };
                        var result = await mediator.Send(command);
                        var book = mapper.Map<BookViewModel>(bookImage.Book);
                    }
                }
            }
            return LocalRedirect(returnUrl);
        }
    }
}
