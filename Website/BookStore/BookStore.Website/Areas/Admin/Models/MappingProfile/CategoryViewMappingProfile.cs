using AutoMapper;
using BookStore.Logic.Shared.Model;

namespace BookStore.Website.Areas.Admin.Models.MappingProfile
{
    public class CategoryViewMappingProfile : Profile
    {
        public CategoryViewMappingProfile()
        {
            CreateMap<CategoryDetailModel, CategoryViewModel>();
        }
    }
}
