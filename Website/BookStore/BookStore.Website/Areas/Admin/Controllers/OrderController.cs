using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Queries.Interface;
using BookStore.Website.Areas.Admin.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IMediator mediator;
        private readonly AppDatabase database;
        private readonly IOrderQueries orderQueries;

        public OrderController(IMediator mediator,
            AppDatabase database,
            IOrderQueries orderQueries)
        {
            this.mediator = mediator;
            this.database = database;
            this.orderQueries = orderQueries;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(OrderViewModel model)
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            List<OrderDetailViewModel> listOrderDetail = new List<OrderDetailViewModel>();
            var orderResult = new BaseCommandResultWithData<Order>();
            var orderDetailResult = new BaseCommandResultWithData<OrderDetail>();

            model.SetFromContext(HttpContext);
            string? orderDetailsGet = HttpContext?.Session.GetString("carts");
            if (orderDetailsGet != null)
            {
                listOrderDetail = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(orderDetailsGet);
            }
            orderResult = await mediator.Send(model.ToCreateCommand());
            if (orderResult.Success)
            {
                foreach (var item in listOrderDetail)
                {
                    item.SetFromContext(HttpContext);
                    orderDetailResult = await mediator.Send(item.ToCreateCommand(orderResult.Data, item.Book.BookId));
                }
            }
            database.SaveChanges();
            return LocalRedirect(Url.Action("Payment", "Shop", new { id = orderResult.Data.OrderId, Area ="" }));
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(OrderViewModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(OrderViewModel model)
        {
            return View();
        }
    }
}
