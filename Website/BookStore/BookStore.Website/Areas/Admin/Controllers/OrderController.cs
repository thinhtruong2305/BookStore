using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Catalog.Interface;
using BookStore.Website.Areas.Admin.Models;
using MailKit.Search;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text.Encodings.Web;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using System.Net.Mail;
using Syncfusion.Drawing;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Reporting.NETCore;
using System.IO;
using BookStore.Logic.Shared.Model;
using BookStore.Website.Models;
using AutoMapper;
using Microsoft.Reporting.Map.WebForms.BingMaps;

namespace BookStore.Website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IMediator mediator;
        private readonly AppDatabase database;
        private readonly IOrderQueries orderQueries;
        private readonly ISendMailService emailSender;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;

        public OrderController(IMediator mediator,
            AppDatabase database,
            IOrderQueries orderQueries,
            ISendMailService emailSender,
            IWebHostEnvironment webHostEnvironment,
            IMapper mapper)
        {
            this.mediator = mediator;
            this.database = database;
            this.orderQueries = orderQueries;
            this.emailSender = emailSender;
            this.webHostEnvironment = webHostEnvironment;
            this.mapper = mapper;
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

            if(model.Email != String.Empty && orderResult.Data.OrderId != Guid.Empty)
            {
                await SendOrderAsync(orderResult, model.Email);
            }
            return LocalRedirect(Url.Action("Payment", "Shop", new { id = orderResult.Data.OrderId, Area ="" }));
        }

        public async Task SendOrderAsync(BaseCommandResultWithData<Order> orderResult, String email)
        {
            // Create a new instance of PdfDocument class.
            PdfDocument document = new PdfDocument();
            // Add a page to the document.
            PdfPage page = document.Pages.Add();
            // Create PDF graphics for the page.
            PdfGraphics g = page.Graphics;
            // Create a solid brush
            PdfBrush brush = new PdfSolidBrush(Color.Black);
            // Set the font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20f);
            // Draw the text.
            g.DrawString("Hello world!", font, brush, new PointF(20, 20));
            byte[] pdfData = null;
            MemoryStream ms = new MemoryStream();
            string filePath = Path.Join(webHostEnvironment.ContentRootPath, "Report\\OrderSender.rdl");
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                LocalReport report = new();
                report.LoadReportDefinition(fileStream);

                List<OrderDetailSenderModel> orderDetailsSender = new List<OrderDetailSenderModel>();
                List<OrderSenderModel> ordersSender = new List<OrderSenderModel>();

                var order = orderQueries.GetDetail(orderResult.Data.OrderId);

                var orderSender = mapper.Map<OrderSenderModel>(order);
                ordersSender.Add(orderSender);
                order.OrderDetails.ForEach(od => {
                    var orderDetailSender = mapper.Map<OrderDetailSenderModel>(od);
                    orderDetailsSender.Add(orderDetailSender);
                });

                report.DataSources.Add(new ReportDataSource(name: "Order", ordersSender));
                report.DataSources.Add(new ReportDataSource(name: "OrderDetail", orderDetailsSender));

                pdfData = report.Render(format: "PDF");
            }

            // Save and close the document.
            document.Save(ms);
            document.Close(true);
            //Reset the memory stream position.  
            ms.Position = 0;
            Attachment file = new Attachment(ms, "HoaDon.pdf", "application/pdf");
            await emailSender.SendEmailWithFileAsync(email,
                        "Hóa đơn thanh toán",
                        @$"Cảm ơn bạn đã mua hàng trên BookStore, 
                               đây là hóa đơn của bạn.", file, pdfData);
        }
    }
}
