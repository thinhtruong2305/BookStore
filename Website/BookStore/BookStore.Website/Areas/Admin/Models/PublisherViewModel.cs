using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using BookStore.Website.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class PublisherViewModel : BaseViewModel
    {
        public int PublisherId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập nhà xuất bản")]
        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Nhà xuất bản")]
        public string PulishingHouse { get; set; }

        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Quốc gia")]
        public string? Country { get; set; }

        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Từ khóa")]
        public string? Keyword { get; set; }

        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Mô tả")]
        public string? Decription { get; set; }

        [Display(Name = "Liên kết")]
        public string Slug { get; set; }

        public CreatePublisherRequest ToCreateCommand()
        {
            return new CreatePublisherRequest
            {
                PulishingHouse = PulishingHouse,
                Country = Country,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(PulishingHouse),
                Status = Common.Shared.Model.Status.Active
            };
        }

        public UpdatePublisherRequest ToUpdateCommand()
        {
            return new UpdatePublisherRequest
            {
                PulishingHouse = PulishingHouse,
                Country = Country,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(PulishingHouse)
            };
        }
    }
}
