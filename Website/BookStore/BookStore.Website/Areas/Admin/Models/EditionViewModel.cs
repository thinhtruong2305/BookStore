﻿using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Website.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class EditionViewModel : BaseViewModel
    {
        public int EditionId { get; set; }

        [RegularExpression(@"/^[0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [StringLength(12, MinimumLength = 1, ErrorMessage = "Bạn phải nhập từ {1} đến {0}")]
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

        [Display(Name = "Giá tiền")]
        public decimal Price { get; set; }

        [RegularExpression(@"/^([1-9])([0-9]{1,10})$/gm", ErrorMessage = "Bạn không được nhập số 0 ở đầu")]
        [Display(Name = "Số trang")]
        public int Pages { get; set; }

        public CreateEditionRequest ToCreateCommand()
        {
            return new CreateEditionRequest
            {
                ISBN = ISBN,
                PublicationDate = PublicationDate,
                Format = Format,
                PrintRunSize = PrintRunSize,
                Price = Price,
                Pages = Pages
            };
        }
        public UpdateEditionRequest ToUpdateCommand()
        {
            return new UpdateEditionRequest
            {
                ISBN = ISBN,
                PublicationDate = PublicationDate,
                Format = Format,
                PrintRunSize = PrintRunSize,
                Price = Price,
                Pages = Pages
            };
        }
    }
}
