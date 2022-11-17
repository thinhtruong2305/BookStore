using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Website.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class OrderViewModel : BaseViewModel
    {
        public int OrderId { get; set; }

        [Display(Name = "Tên khách hàng")]
        public string ShipName { get; set; }

        [Display(Name = "Địa chỉ khách hàng")]
        public string ShipAdress { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string ShipPhone { get; set; }
        public decimal TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public CreateOrderRequest ToCreateCommand()
        {
            return new CreateOrderRequest
            {
                ShipName = ShipName,
                ShipAdress = ShipAdress,
                ShipPhone = ShipPhone,
                TotalPrice = TotalPrice,
                Status = Common.Shared.Model.Status.Unpaid,
                OrderDetails = OrderDetails
            };
        }
    }
}
