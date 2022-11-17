using BookStore.DAL.Entities;
using BookStore.Logic.Queries.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using BookStore.Website.Areas.Admin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;
using BookStore.Logic.Shared.Catalog.Interface;

namespace BookStore.Website.Controllers
{
    public class ShopController : Controller
    {
        public const string CARTS = "carts";
        private readonly IBookQueries bookQueries;
        private readonly IOrderQueries orderQueries;
        private readonly ISendMailService emailSender;

        public ShopController(IBookQueries bookQueries,
            IOrderQueries orderQueries,
            ISendMailService emailSender)
        {
            this.bookQueries = bookQueries;
            this.orderQueries = orderQueries;
            this.emailSender = emailSender;
        }
        public IActionResult Index()
        {
            var model = bookQueries.GetAllClient();
            return View(model);
        }

        [Route("{controller}/SingleProduct/{Slug}-{id}")]
        public IActionResult SingleProduct(int id)
        {
            var model = bookQueries.GetDetailClient(id);
            ViewBag.books = bookQueries.GetAllClient();
            return View(model);
        }
        [HttpPost]
        public IActionResult Checkout([FromForm] IFormCollection form)
        {
            OrderViewModel order = new OrderViewModel();
            List<OrderDetailViewModel> orderDetails = new List<OrderDetailViewModel>();
            var session = HttpContext.Session;
            string? cartGet = session.GetString(CARTS);
            int items = (form.Count - 4) / 5;
            for (int i = 1; i < items + 1; i++)
            {
                OrderDetailViewModel orderDetail = new OrderDetailViewModel();
                foreach(var item in form)
                {
                    Book book = new Book();
                    if(item.Key == $"chr_item_{i}")
                    {
                        string volume = "";
                        string title = "";
                        String objStr = item.Value.ToString();
                        int intLength = objStr.Length;

                        if ("" != objStr)
                        {
                            //MessageBox.Show(objStr.Length.ToString());
                            for (int j = 0; j < intLength; j++)
                            {
                                if (!Char.IsDigit(objStr[j]))
                                {
                                    title += objStr[j];
                                }
                                else
                                {
                                    volume += objStr[j];
                                }
                            }
                        }
                        book = bookQueries.GetBookByTitleAndVolumNumber(title, Convert.ToInt32(volume));
                        orderDetail.Book = book;
                    }
                    if (item.Key == $"quantity_{i}")
                    {
                        orderDetail.Quantity = Convert.ToInt32(item.Value);
                    }
                    if (item.Key == $"amount_{i}")
                    {
                        orderDetail.Payment = Convert.ToDecimal(item.Value);
                    }
                    if (item.Key == $"discount_amount_{i}")
                    {
                        orderDetail.DiscountPrice = Convert.ToDecimal(item.Value);
                    }
                    if (orderDetail.Book != null && orderDetail.Quantity != 0 && orderDetail.Payment != 0 && orderDetail.DiscountPrice != 0)
                    {
                        orderDetail.Payment = orderDetail.Payment * orderDetail.Quantity;
                        break;
                    }
                }
                orderDetails.Add(orderDetail);
            }
            string carts = JsonConvert.SerializeObject(orderDetails, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            session.SetString(CARTS, carts);
            return View(order);
        }
        public IActionResult Payment(int id)
        {
            if (id != 0)
            {
                var model = orderQueries.GetDetail(id);
                return View(model);
            }
            return RedirectToAction("Index", "Shop");
        }
        [HttpPost]
        public async Task<IActionResult> SendMailAsync(IFormCollection form)
        {
            int OrderId = 0;
            string email = "";
            foreach (var item in form)
            {
                if (item.Key == "OrderId")
                {
                    OrderId = Convert.ToInt32(item.Value);
                }
                if (item.Key == "Email")
                {
                    email = item.Value.ToString();
                }
            }
            var callbackUrl = Url.ActionLink("Payment", "Shop", new{ area = "", id = OrderId}, Request.Scheme);
            await emailSender.SendEmailAsync(email,
                        "Xác nhận địa chỉ email",
                        @$"Cảm ơn bạn đã mua hàng trên BookStore, 
                               đây là hóa đơn của bạn <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>bấm vào đây</a> 
                               để xem hóa đơn.");
            return RedirectToAction("Index", "Home");
        }
    }
}
