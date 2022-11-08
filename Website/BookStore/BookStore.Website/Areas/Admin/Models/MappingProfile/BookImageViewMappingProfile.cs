using AutoMapper;
using BookStore.DAL.Entities;

namespace BookStore.Website.Areas.Admin.Models.MappingProfile
{
    public class BookImageViewMappingProfile : Profile
    {
        public BookImageViewMappingProfile()
        {
            CreateMap<BookImage, BookImageViewModel>()
                .ReverseMap();
        }
    }
}
