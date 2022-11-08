using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Queries.Interface;
using BookStore.Utils.Extension;
using BookStore.Utils.Global;
using BookStore.Website.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Internal;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        public const string TAGS = "tags";
        private readonly ITagQueries tagQueries;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public TagController(ITagQueries tagQueries,
            IMapper mapper,
            IMediator mediator)
        {
            this.tagQueries = tagQueries;
            this.mapper = mapper;
            this.mediator = mediator;
        }
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

        public IActionResult AddTagToSession(string returnUrl)
        {
            TagViewModel model = new TagViewModel();
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTagToSession(TagViewModel model)
        {
            if (ModelState.IsValid)
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
                string? decodedHtml = System.Net.WebUtility.HtmlDecode(model.Decription);
                model.Decription = decodedHtml;
                list.Add(model);
                string tags = JsonConvert.SerializeObject(list);
                session.SetString(TAGS, tags);
                return Redirect(model.ReturnUrl);
            }
            return Json(new { success = false, message = "Thao tác thêm thể loại sai vui lòng thử lại", html = AppGlobal.RenderRazorViewToString(this, "AddTagToSession", model) });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTagFromSessionAsync(string returnUrl, int id)
        {
            var session = HttpContext.Session;
            string? tagGet = session.GetString(TAGS);
            if (tagGet != null)
            {
                List<TagViewModel>? list = JsonConvert.DeserializeObject<List<TagViewModel>>(tagGet);
                if (list != null)
                {
                    var tag = tagQueries.GetDetail(id);
                    if (tag == null)
                    {
                        list.RemoveAt(id);
                        string tags = JsonConvert.SerializeObject(list);
                        session.SetString(TAGS, tags);
                    }
                    else
                    {
                        var command = new DeleteTagRequest()
                        {
                            Id = id,
                            RequestId = HttpContext.Connection?.Id,
                            IpAddress = HttpContext.Connection?.RemoteIpAddress?.ToString(),
                            UserName = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value
                        };
                        var result = await mediator.Send(command);
                        var book = mapper.Map<BookViewModel>(tag);
                    }
                }
            }
            return RedirectToAction(returnUrl);
        }

        [HttpGet]
        public IActionResult UpdateTagToSession(string returnUrl, int id)
        {
            TagViewModel model = new TagViewModel();
            var session = HttpContext.Session;
            string? tagGet = session.GetString(TAGS);
            if (tagGet != null)
            {
                List<TagViewModel>? list = JsonConvert.DeserializeObject<List<TagViewModel>>(tagGet);
                if (list != null)
                {
                    var tag = mapper.Map<TagViewModel>(tagQueries.GetDetail(id));
                    if (tag == null)
                    {
                        model = list[id];
                        model.ReturnUrl = returnUrl;
                    }
                    else 
                    {
                        model = tag;
                        model.ReturnUrl = returnUrl;
                    }
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetFromContext(HttpContext);
                var commandResult = new BaseCommandResultWithData<Tag>();
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
        [HttpPost]
        public IActionResult Delete(TagViewModel model)
        {
            return View();
        }
    }
}
