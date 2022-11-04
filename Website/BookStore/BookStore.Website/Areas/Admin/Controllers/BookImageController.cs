using BookStore.DAL.Entities;
using BookStore.Logic.Shared.Catalog.Interface;
using BookStore.Utils.Extension;
using BookStore.Website.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookImageController : Controller
    {
        private readonly IFileStorageService storageService;
        public const string BOOKIMAGES = "bookimages";

        public BookImageController(IFileStorageService storageService)
        {
            this.storageService = storageService;
        }

        [HttpGet]
        public IActionResult AddBookImageToSession()
        {
            BookImageViewModel model = new BookImageViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookImageToSessionAsync([FromForm] BookImageViewModel model, IFormFile FileUpLoad)
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
            if (FileUpLoad != null)
            {
                string path = await storageService.SaveFile(FileUpLoad);
                model.FilePath = path;
                list.Add(model);
                string bookImages = JsonConvert.SerializeObject(list);
                session.SetString(BOOKIMAGES, bookImages);
                return View("~/Areas/Admin/Views/Book/Create.cshtml");
            }
            ModelState.GetError();
            return View("~/Areas/Admin/Views/Book/Create.cshtml");
        }

        public IActionResult ClearAllBookImagesSession()
        {
            var session = HttpContext.Session;
            string? bookImages = session.GetString(BOOKIMAGES);
            if (bookImages != null)
            {
                List<BookImageViewModel>? list = JsonConvert.DeserializeObject<List<BookImageViewModel>>(bookImages);
                if (list != null)
                {
                    list.ForEach(async item =>
                    {
                        await storageService.DeleteFileAsync(item.FilePath);
                    });
                }
            }
            return RedirectToAction("Create", "Book");
        }
    }
}
