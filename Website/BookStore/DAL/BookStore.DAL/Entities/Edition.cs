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
    [Table("Edition")]
    public class Edition : BaseEntity
    {
        public int EditionId { get; set; }
        public int BookId { get; set; }
        public int PublisherId { get; set; }

        [RegularExpression(@"/^[0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Bạn phải nhập từ {1} đến {0}")]
        [Display(Name = "Mã sách")]
        public string ISBN { get; set; }

        [RegularExpression(@"^(?:(?:31(\/)(?:0?[13578]|1[02]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec)))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/)(?:0?2|(?:Feb))\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/)(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Bạn phải nhập dd/MM/yyyy hoặc dd/MMM/yyyy")]
        [Display(Name = "Ngày xuất bản")]
        public DateTime PublicationDate { get; set; }

        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Định dạng")]
        public string? Format { get; set; }

        [RegularExpression(@"/^([0-9]{0,4})(\,[0-9]{0,4})(\s[a-z])(\s([0-9]{0,4})(\,[0-9]{0,4}))(\s[a-z]{1,3})$/gm", ErrorMessage = "Bạn phải nhập các ký tự theo mẫu **,** x **,** đơn vị đo")]
        [Display(Name = "Kích cỡ")]
        public string? PrintRunSize { get; set; }

        [RegularExpression(@"/^((?=.*[1-9]|0)(?:\d{1,3}))((?=.*\d)(?:\.\d{3})?)*((?=.*\d)(?:\,\d\d){1}?){0,1}$/gm", ErrorMessage = "Bạn phải nhập các định dạng tiền 1.000.000")]
        [Display(Name = "Giá tiền")]
        public decimal Price { get; set; }

        [RegularExpression(@"/^([1-9])([0-9]{1,10})$/gm", ErrorMessage = "Bạn không được nhập số 0 ở đầu")]
        [Display(Name = "Số trang")]
        public int Pages { get; set; }
        public Book Book { get; set; }
        public List<EditionPublisher> EditionPublishers { get; set; }
    }
}
