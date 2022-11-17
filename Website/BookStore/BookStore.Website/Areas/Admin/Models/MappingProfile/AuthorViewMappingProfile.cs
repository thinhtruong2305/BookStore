using AutoMapper;
using BookStore.Logic.Shared.Model;

namespace BookStore.Website.Areas.Admin.Models.MappingProfile
{
    public class AuthorViewMappingProfile : Profile
    {
        public AuthorViewMappingProfile()
        {
            CreateMap<AuthorDetailModel, AuthorViewModel>()
                .ReverseMap();
        }
    }
}
