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
        public const string BOOKIMAGES = "bookimages";

        public BookImageController(IFileStorageService storageService,
            IBookImageQueries bookImageQueries,
            IMediator mediator,
            IMapper mapper)
        {
            this.storageService = storageService;
            this.bookImageQueries = bookImageQueries;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult AddBookImageToSession()
        {
            BookImageViewModel model = new BookImageViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBookImageToSession([FromForm] BookImageViewModel model, IFormFile FileUpLoad)
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
                return View("~/Areas/Admin/Views/Book/Create.cshtml");
            }
            return Json(new { isValid = false, html = AppGlobal.RenderRazorViewToString(this, "AddBookImageToSession", model) });
        }

        [HttpGet]
        public async Task<IActionResult> RemoveBookImageFromSession(int id)
        {
            var session = HttpContext.Session;
            string? bookImagesGet = session.GetString(BOOKIMAGES);
            if (bookImagesGet != null)
            {
                List<BookImageViewModel>? list = JsonConvert.DeserializeObject<List<BookImageViewModel>>(bookImagesGet);
                if (list != null)
                {
                    var bookImage =bookImageQueries.GetBookImageById(id);

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
                        return RedirectToAction("Detail", "Book", book);
                    }
                }
            }
            return RedirectToAction("Detail", "Book");
        }
    }
}
