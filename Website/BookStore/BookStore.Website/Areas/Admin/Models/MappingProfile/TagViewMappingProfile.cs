using AutoMapper;
using BookStore.Logic.Shared.Model;

namespace BookStore.Website.Areas.Admin.Models.MappingProfile
{
    public class TagViewMappingProfile : Profile
    {
        public TagViewMappingProfile()
        {
            CreateMap<TagDetailModel, TagViewModel>()
                .ReverseMap();
        }
    }
}
