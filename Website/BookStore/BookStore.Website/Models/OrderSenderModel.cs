namespace BookStore.Website.Models
{
    public class OrderSenderModel
    {
        public string ShipName { get; set; }
        public string ShipPhone { get; set; }
        public string ShipAdress { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
