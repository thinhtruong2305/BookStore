using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Utils.Global;
using BookStore.Website.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PublisherController : Controller
    {
        public const string PUBLISHERS = "publishers";
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PublisherViewModel model)
        {

            return View();
        }

        [HttpGet]
        public IActionResult AddPublisherToSession()
        {
            PublisherViewModel model = new PublisherViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPublisherToSession([FromForm] PublisherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var session = HttpContext.Session;
                List<PublisherViewModel> list = new List<PublisherViewModel>();

                string? publisherGet = session.GetString(PUBLISHERS);
                if (publisherGet != null)
                {
                    List<PublisherViewModel>? listGet = JsonConvert.DeserializeObject<List<PublisherViewModel>>(publisherGet);
                    if (listGet != null)
                    {
                        list = listGet;
                    }
                }
                string? decodedHtml = System.Net.WebUtility.HtmlDecode(model.Decription);
                model.Decription = decodedHtml;
                list.Add(model);
                string publishers = JsonConvert.SerializeObject(list);
                session.SetString(PUBLISHERS, publishers);
                return View("~/Areas/Admin/Views/Book/Create.cshtml");
            }
            return Json(new { isValid = false, html = AppGlobal.RenderRazorViewToString(this, "AddPublisherToSession", model) });
        }

        public IActionResult DeletePublisherFromSession(int id)
        {
            var session = HttpContext.Session;
            string? publisherGet = session.GetString(PUBLISHERS);
            if (publisherGet != null)
            {
                List<PublisherViewModel>? list = JsonConvert.DeserializeObject<List<PublisherViewModel>>(publisherGet);
                if (list != null)
                {
                    list.RemoveAt(id);
                    string publisher = JsonConvert.SerializeObject(list);
                    session.SetString(PUBLISHERS, publisher);
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
        public IActionResult Update(PublisherViewModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(PublisherViewModel model)
        {
            return View();
        }
    }
}
