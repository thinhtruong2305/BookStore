using BookStore.Common.Shared.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    [Table("OrderDetail")]
    public class OrderDetail : BaseEntity
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal Payment { get; set; }
        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
