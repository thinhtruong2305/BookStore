using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class OrderSummaryModel
    {
        public Guid OrderId { get; set; }
        public string ShipName { get; set; }
        public string ShipAdress { get; set; }
        public string ShipPhone { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderAt { get; set; }
    }
}
