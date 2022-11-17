using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using BookStore.Website.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookStore.Website.Areas.Admin.Models
{
    public class TagViewModel : BaseViewModel
    {
        public int TagId { get; set; }
        public int? ParentId { get; set; }
        public int? InfoId { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên tag")]
        [Display(Name = "Tên tag")]
        public string TagName { get; set; }
        
        [Display(Name = "Từ khóa")]
        public string? Keyword { get; set; }

        [Display(Name = "Mô tả")]
        public string? Decription { get; set; }

        [Display(Name = "Liên kết")]
        public string? Slug { get; set; }
        public string? ReturnUrl { get; set; }

        public CreateTagRequest ToCreateCommand()
        {
            return new CreateTagRequest
            {
                TagName = TagName,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(TagName),
                Status = Common.Shared.Model.Status.Active,
                ParentId = null,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }

        public UpdateTagRequest ToUpdateCommand()
        {
            return new UpdateTagRequest
            {
                TagName = TagName,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(TagName),
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
    }
}
