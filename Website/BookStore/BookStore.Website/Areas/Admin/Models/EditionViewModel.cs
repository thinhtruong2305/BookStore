using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Website.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class EditionViewModel : BaseViewModel
    {
        public int EditionId { get; set; }

        [Display(Name = "Mã sách")]
        public string? ISBN { get; set; }

        [Display(Name = "Ngày xuất bản")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Định dạng")]
        public string? Format { get; set; }

        [Display(Name = "Kích cỡ")]
        public string? PrintRunSize { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Giá tiền")]
        public decimal Price { get; set; }

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
                Pages = Pages,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
        public UpdateEditionRequest ToUpdateCommand(int BookId)
        {
            return new UpdateEditionRequest
            {
                EditionId = EditionId,
                BookId = BookId,
                ISBN = ISBN,
                PublicationDate = PublicationDate,
                Format = Format,
                PrintRunSize = PrintRunSize,
                Price = Price,
                Pages = Pages,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
    }
}
