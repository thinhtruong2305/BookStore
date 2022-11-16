using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Queries.Implement;
using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Model;
using BookStore.Utils.Extension;
using BookStore.Utils.Global;
using BookStore.Website.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Security.Claims;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryQueries categoryQueries;
        private readonly IMediator mediator;
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CategoryController(ICategoryQueries categoryQueries,
            IMediator mediator,
            AppDatabase database,
            IMapper mapper)
        {
            this.categoryQueries = categoryQueries;
            this.mediator = mediator;
            this.database = database;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var model = new List<CategorySummaryModel>();
            model = categoryQueries.GetAll();
            return View(model);
        }

        public IActionResult List()
        {
            var model = new List<CategorySummaryModel>();
            model = categoryQueries.GetAll();
            return PartialView(model);
        }

        public IActionResult Trash()
        {
            var model = new List<CategorySummaryModel>();
            model = categoryQueries.GetAllDelete();
            return View(model);
        }
        public IActionResult ListTrash()
        {
            var model = new List<CategorySummaryModel>();
            model = categoryQueries.GetAllDelete();
            return PartialView(model);
        }
        [HttpGet]
        public async Task<IActionResult> StatusAsync(int id)
        {
            var command = new ChangeCategoryStatusRequest()
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
            CategoryViewModel model = new CategoryViewModel();
            if (categoryQueries.GetAll().Count > 0)
            {
                model.Categories = categoryQueries.GetAll();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetFromContext(HttpContext);
                var commandResult = new BaseCommandResultWithData<Category>();

                if (model.CategoryId == 0)
                {
                    var createCommand = model.ToCreateCommand();
                    commandResult = await mediator.Send(createCommand);
                }
                else
                {
                    var updateCommand = model.ToUpdateCommand();
                    commandResult = await mediator.Send(updateCommand);
                }

                if (commandResult.Success)
                {
                    database.SaveChanges();
                    return RedirectToAction("Index", "Category");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            CategoryViewModel model = new CategoryViewModel();
            model = mapper.Map<CategoryViewModel>(categoryQueries.GetDetail(id));
            if (categoryQueries.GetAll().Count > 0)
            {
                model.Categories = categoryQueries.GetAll();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SetFromContext(HttpContext);
                var commandResult = new BaseCommandResultWithData<Category>();

                if (model.CategoryId == 0)
                {
                    var createCommand = model.ToCreateCommand();
                    commandResult = await mediator.Send(createCommand);
                }
                else
                {
                    var updateCommand = model.ToUpdateCommand();
                    commandResult = await mediator.Send(updateCommand);
                }

                if (commandResult.Success)
                {
                    database.SaveChanges();
                    return RedirectToAction("Index", "Category");
                }
            }
            return View();
        }
    }
}
