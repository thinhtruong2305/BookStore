using BookStore.Common.Shared.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên khách hàng")]
        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Tên khách hàng")]
        public string ShipName { get; set; }
        public string ShipAdress { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tiêu đề của sách")]
        [RegularExpression(@"/^[0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Tiêu đề")]
        public string ShipPhone { get; set; }
        public double TotalPrice { get; set; }
        public DateTime OrderAt { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
