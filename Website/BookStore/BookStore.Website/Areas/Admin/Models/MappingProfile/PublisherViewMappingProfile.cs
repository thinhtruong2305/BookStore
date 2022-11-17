using AutoMapper;
using BookStore.Logic.Shared.Model;

namespace BookStore.Website.Areas.Admin.Models.MappingProfile
{
    public class PublisherViewMappingProfile : Profile
    {
        public PublisherViewMappingProfile()
        {
            CreateMap<PublisherDetailModel, PublisherViewModel>()
                .ReverseMap();
        }
    }
}
