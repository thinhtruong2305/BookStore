namespace BookStore.Website.Models
{
    public class OrderDetailSenderModel
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Payment { get; set; }
        public decimal Price { get; set; }
    }
}
