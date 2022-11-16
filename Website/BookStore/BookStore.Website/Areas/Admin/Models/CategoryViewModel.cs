using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Logic.Shared.Model;
using BookStore.Utils.Global;
using BookStore.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Website.Areas.Admin.Models
{
    [BindProperties]
    public class CategoryViewModel : BaseViewModel
    {
        public int CategoryId { get; set; }
        [Display(Name = "Danh mục cha")]
        public int ParentId { get; set; } = 0;
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        public string? Slug { get; set; }
        public int Orders { get; set; }
        [Display(Name = "Từ khóa")]
        public string? Keyword { get; set; }
        [Display(Name = "Mô tả")]
        public string? Decription { get; set; }
        public List<CategorySummaryModel>? Categories { get; set; }
        public CreateCategoryRequest ToCreateCommand()
        {
            return new CreateCategoryRequest
            {
                Name = Name,
                ParentId = ParentId,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Name),
                Status = Common.Shared.Model.Status.Active,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }

        public UpdateCategoryRequest ToUpdateCommand()
        {
            return new UpdateCategoryRequest
            {
                CategoryId = CategoryId,
                Name = Name,
                ParentId = ParentId,
                Keyword = Keyword,
                Decription = Decription,
                Slug = AppGlobal.GenerateSlug(Name),
                Status = Common.Shared.Model.Status.Active,
                UserName = UserName,
                IpAddress = IpAddress,
                RequestId = RequestId
            };
        }
    }
}
