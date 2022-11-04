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
        [RegularExpression(@"/^[a-zA-Z0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [a-zA-Z0-9]")]
        [Display(Name = "Tên series")]
        public string SeriesName { get; set; }

        [RegularExpression(@"/^[0-9]+$/", ErrorMessage = "Bạn phải nhập các ký tự [0-9]")]
        [Display(Name = "Đầu sách sắp ra")]
        public int? PlannedVolume { get; set; }

        public CreateSeriesRequest ToCreateCommand()
        {
            return new CreateSeriesRequest()
            {
                SeriesName = SeriesName,
                PlannedVolume = PlannedVolume
            };
        }
        public UpdateSeriesRequest ToUpdateCommand()
        {
            return new UpdateSeriesRequest()
            {
                SeriesName = SeriesName,
                PlannedVolume = PlannedVolume,
                Status = Common.Shared.Model.Status.Active
            };
        }
    }
}
