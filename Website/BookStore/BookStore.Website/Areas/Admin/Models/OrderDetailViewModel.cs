using BookStore.DAL.Entities;

namespace BookStore.Website.Areas.Admin.Models
{
    public class OrderDetailViewModel
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal Payment { get; set; }
        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
