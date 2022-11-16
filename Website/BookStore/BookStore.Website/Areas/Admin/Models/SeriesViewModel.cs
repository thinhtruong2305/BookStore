using BookStore.Logic.Command.Request;
using BookStore.Website.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class SeriesViewModel : BaseViewModel
    {
        public int SeriesId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên của bộ")]
        [Display(Name = "Tên series")]
        public string SeriesName { get; set; }

        [Display(Name = "Đầu sách sắp ra")]
        public int? PlannedVolume { get; set; }

        public CreateSeriesRequest ToCreateCommand()
        {
            return new CreateSeriesRequest()
            {
                SeriesName = SeriesName,
                PlannedVolume = PlannedVolume,
                Status = Common.Shared.Model.Status.Active,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
        public UpdateSeriesRequest ToUpdateCommand()
        {
            return new UpdateSeriesRequest()
            {
                SeriesId = SeriesId,
                SeriesName = SeriesName,
                PlannedVolume = PlannedVolume,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
    }
}
