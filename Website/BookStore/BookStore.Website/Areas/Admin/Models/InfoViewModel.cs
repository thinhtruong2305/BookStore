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

        [RegularExpression(@"/^[0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [0-9]")]
        [Display(Name = "Phần trăm giảm giá")]
        public int? DiscountPercent { get; set; }

        [RegularExpression(@"/^[a-zA-Z]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z]")]
        [Display(Name = "Ngôn ngữ")]
        public string? Language { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập đầu sách (tập)")]
        [RegularExpression(@"/^[0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [0-9]")]
        [Display(Name = "Đầu sách")]
        public int VolumeNumber { get; set; }

        public CreateInfoRequest ToCreateCommand()
        {
            return new CreateInfoRequest
            {
                DiscountPercent = DiscountPercent,
                Language = Language,
                VolumeNumber = VolumeNumber,
                Status = Common.Shared.Model.Status.Active
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
                Series = series
            };
        }
        public CreateInfoRequest ToCreateCommand(List<Tag> tags)
        {
            return new CreateInfoRequest
            {
                DiscountPercent = DiscountPercent,
                Language = Language,
                VolumeNumber = VolumeNumber,
                Status = Common.Shared.Model.Status.Active,
                Tags = tags
            };
        }
        public CreateInfoRequest ToCreateCommand(Series series, List<Tag> tags)
        {
            return new CreateInfoRequest
            {
                DiscountPercent = DiscountPercent,
                Language = Language,
                VolumeNumber = VolumeNumber,
                Status = Common.Shared.Model.Status.Active,
                Series = series,
                Tags = tags
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
                Status = Common.Shared.Model.Status.Active
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
                Series = series
            };
        }
        public UpdateInfoRequest ToUpdateCommand(List<Tag> tags)
        {
            return new UpdateInfoRequest
            {
                DiscountPercent = DiscountPercent,
                Language = Language,
                VolumeNumber = VolumeNumber,
                Status = Common.Shared.Model.Status.Active,
                Tags = tags
            };
        }
        public UpdateInfoRequest ToUpdateCommand(Series series, List<Tag> tags)
        {
            return new UpdateInfoRequest
            {
                DiscountPercent = DiscountPercent,
                Language = Language,
                VolumeNumber = VolumeNumber,
                Status = Common.Shared.Model.Status.Active,
                Series = series,
                Tags = tags
            };
        }
    }
}
