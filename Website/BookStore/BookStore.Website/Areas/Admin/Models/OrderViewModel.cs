using BookStore.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên")]
        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Tên khách hàng")]
        public string ShipName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên địa chỉ")]
        [Display(Name = "Địa chỉ khách hàng")]
        public string ShipAdress { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        [RegularExpression(@"/^[0-9]{0,10}$/gm", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Số điện thoại")]
        public string ShipPhone { get; set; }
        public double TotalPrice { get; set; }
    }
}
