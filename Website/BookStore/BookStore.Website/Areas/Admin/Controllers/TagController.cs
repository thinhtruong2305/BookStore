using BookStore.DAL.Entities;
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
    public class TagController : Controller
    {
        public const string TAGS = "tags";
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
        public IActionResult Create(TagViewModel model)
        {

            return View();
        }

        [HttpGet]
        public IActionResult AddTagToSession()
        {
            TagViewModel model = new TagViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddTagToSession([FromForm] TagViewModel model)
        {
            var session = HttpContext.Session;
            List<TagViewModel> list = new List<TagViewModel>();

            string? tagGet = session.GetString(TAGS);
            if (tagGet != null)
            {
                List<TagViewModel>? listGet = JsonConvert.DeserializeObject<List<TagViewModel>>(tagGet);
                if (listGet != null)
                {
                    list = listGet;
                }
            }
            list.Add(model);
            string tags = JsonConvert.SerializeObject(list);
            session.SetString(TAGS, tags);
            return View("~/Areas/Admin/Views/Book/Create.cshtml");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(TagViewModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(TagViewModel model)
        {
            return View();
        }
    }
}
