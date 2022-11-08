using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Website.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class InfoViewModel : BaseViewModel
    {
        public int InfoId { get; set; }

        [Display(Name = "Phần trăm giảm giá")]
        public int? DiscountPercent { get; set; }

        [Display(Name = "Ngôn ngữ")]
        public string? Language { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập đầu sách (tập)")]
        [Display(Name = "Đầu sách")]
        public int VolumeNumber { get; set; }

        public CreateInfoRequest ToCreateCommand()
        {
            return new CreateInfoRequest
            {
                DiscountPercent = DiscountPercent,
                Language = Language,
                VolumeNumber = VolumeNumber,
                Status = Common.Shared.Model.Status.Active,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
        public CreateInfoRequest ToCreateCommand(Series series)
        {
            return new CreateInfoRequest
            {
                DiscountPercent = DiscountPercent,
                Language = Language,
                VolumeNumber = VolumeNumber,
                Status = Common.Shared.Model.Status.Active,
                Series = series,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }

        public UpdateInfoRequest ToUpdateCommand()
        {
            return new UpdateInfoRequest
            { 
                InfoId = InfoId,
                DiscountPercent = DiscountPercent,
                Language = Language,
                VolumeNumber = VolumeNumber,
                Status = Common.Shared.Model.Status.Active,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
        public UpdateInfoRequest ToUpdateCommand(Series series)
        {
            return new UpdateInfoRequest
            {
                DiscountPercent = DiscountPercent,
                Language = Language,
                VolumeNumber = VolumeNumber,
                Status = Common.Shared.Model.Status.Active,
                Series = series,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
    }
}
