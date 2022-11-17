using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Queries.Interface;
using BookStore.Utils.Extension;
using BookStore.Utils.Global;
using BookStore.Website.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        private readonly AppDatabase database;

        public TagController(ITagQueries tagQueries,
            IMapper mapper,
            IMediator mediator,
            AppDatabase database)
        {
            this.tagQueries = tagQueries;
            this.mapper = mapper;
            this.mediator = mediator;
            this.database = database;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTagToBook(string returnUrl, int InfoId)
        {
            TagViewModel model = new TagViewModel();
            model.InfoId = InfoId;
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TagViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tagSave = new Tag();
                var tag = tagQueries.GetTagByName(model.TagName);
                if(tag == null)
                {
                    var tagResult = new BaseCommandResultWithData<Tag>();
                    tagResult = await mediator.Send(model.ToCreateCommand());
                    tagSave = tagResult.Data;
                }
                tagSave = tag;
                if (model.InfoId != 0)
                {
                    var info = database.Infos
                         .Where(i => i.Status != Status.Delete)
                         .FirstOrDefault(i => i.InfoId == model.InfoId);
                    if (info != null)
                    {
                        var tagInfoResult = new BaseCommandResultWithData<TagInfo>();
                        tagInfoResult = await mediator.Send(new AddTagAndInfoToTagInfoRequest
                        {
                            Tag = tagSave,
                            Info = info
                        });
                    }
                }
            }
            database.SaveChanges();
            return LocalRedirect(model.ReturnUrl);
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
            }
            return LocalRedirect(model.ReturnUrl ?? "/Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteTagFromBookAsync(string returnUrl, int id, int TagId, int InfoId)
        {
            var session = HttpContext.Session;
            string? tagGet = session.GetString(TAGS);
            if (tagGet != null)
            {
                List<TagViewModel>? list = JsonConvert.DeserializeObject<List<TagViewModel>>(tagGet);
                if (list != null)
                {
                    var tag = tagQueries.GetDetail(TagId);
                    if (tag == null)
                    {
                        list.RemoveAt(id);
                        string tags = JsonConvert.SerializeObject(list);
                        session.SetString(TAGS, tags);
                    }
                    else
                    {
                        var command = new DeleteTagInfoRequest()
                        {
                            TagId = TagId,
                            InfoId = InfoId,
                            RequestId = HttpContext.Connection?.Id,
                            IpAddress = HttpContext.Connection?.RemoteIpAddress?.ToString(),
                            UserName = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value
                        };
                        var result = await mediator.Send(command);
                    }
                }
            }
            return LocalRedirect(returnUrl ?? "/Admin");
        }

        [HttpGet]
        public IActionResult UpdateTagToBook(string returnUrl, int id)
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
