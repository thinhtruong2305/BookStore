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
        [Display(Name = "Nhà xuất bản")]
        public string PulishingHouse { get; set; }

        [Display(Name = "Quốc gia")]
        public string? Country { get; set; }

        [Display(Name = "Từ khóa")]
        public string? Keyword { get; set; }

        [Display(Name = "Mô tả")]
        public string? Decription { get; set; }

        [Display(Name = "Liên kết")]
        public string? Slug { get; set; }

        public CreatePublisherRequest ToCreateCommand()
        {
            return new CreatePublisherRequest
            {
                PulishingHouse = PulishingHouse,
                Country = Country,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(PulishingHouse),
                Status = Common.Shared.Model.Status.Active,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
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
                Slug = AppGlobal.GenerateSlug(PulishingHouse),
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
    }
}
