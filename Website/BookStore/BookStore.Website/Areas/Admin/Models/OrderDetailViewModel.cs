using BookStore.Common.Shared.Model;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Website.Models;

namespace BookStore.Website.Areas.Admin.Models
{
    public class OrderDetailViewModel : BaseViewModel
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Payment { get; set; }
        public Order Order { get; set; }
        public Book Book { get; set; }

        public CreateOrderDetailRequest ToCreateCommand(Order Order, int BookId)
        {
            return new CreateOrderDetailRequest
            {
                Quantity = Quantity,
                Payment = Payment,
                DiscountPrice = DiscountPrice,
                BookId = BookId,
                Status = Status.Active,
                Order = Order
            };
        }
    }
}
