using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Queries.Implement;
using BookStore.Logic.Queries.Interface;
using BookStore.Utils.Global;
using BookStore.Website.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net;
using System.Security.Claims;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PublisherController : Controller
    {
        public const string PUBLISHERS = "publishers";
        private readonly IPublisherQueries publisherQueries;
        private readonly IMediator mediator;
        private readonly AppDatabase database;

        public PublisherController(IPublisherQueries publisherQueries,
            IMediator mediator,
            AppDatabase database)
        {
            this.publisherQueries = publisherQueries;
            this.mediator = mediator;
            this.database = database;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreatePublisherToBook(string returnUrl, int EditionId)
        {
            PublisherViewModel model = new PublisherViewModel();
            model.EditionId = EditionId;
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PublisherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var publisherSave = new Publisher();
                var publisher = publisherQueries.GetPublisherByPulishingHouse(model.PulishingHouse);
                if (publisher == null)
                {
                    var publisherResult = new BaseCommandResultWithData<Publisher>();
                    publisherResult = await mediator.Send(model.ToCreateCommand());
                    publisherSave = publisherResult.Data;
                }
                publisherSave = publisher;
                if (model.EditionId != 0)
                {
                    var edition = database.Editions
                         .Where(e => e.Status != Status.Delete)
                         .FirstOrDefault(e => e.EditionId == model.EditionId);
                    if (edition != null)
                    {
                        var authorBookResult = new BaseCommandResultWithData<EditionPublisher>();
                        authorBookResult = await mediator.Send(new AddEditionAndPublisherToEditionPubliserRequest
                        {
                            Edition = edition,
                            Publisher = publisherSave
                        });
                    }
                }
            }
            database.SaveChanges();
            return LocalRedirect(model.ReturnUrl);
        }

        [HttpGet]
        public IActionResult AddPublisherToSession(string returnUrl)
        {
            PublisherViewModel model = new PublisherViewModel();
            model.ReturnUrl = returnUrl;
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
            }
            return LocalRedirect(model.ReturnUrl ?? "/Admin");
        }

        public async Task<IActionResult> DeletePublisherFromBookAsync(string returnUrl, int id, int PublisherId, int EditionId)
        {
            var session = HttpContext.Session;
            string? publisherGet = session.GetString(PUBLISHERS);
            if (publisherGet != null)
            {
                List<PublisherViewModel>? list = JsonConvert.DeserializeObject<List<PublisherViewModel>>(publisherGet);
                if (list != null)
                {
                    var publisher = publisherQueries.GetDetail(PublisherId);
                    if (publisher == null)
                    {
                        list.RemoveAt(id);
                        string publishers = JsonConvert.SerializeObject(list);
                        session.SetString(PUBLISHERS, publishers);
                    }
                    else
                    {
                        var command = new DeleteEditionPublisherRequest()
                        {
                            PublisherId = PublisherId,
                            EditionId = EditionId,
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
