using AutoMapper;
using BookStore.DAL.Entities;
using BookStore.Logic.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.MappingProfile
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            new BookMappingProfile();

            //Map cho phần hiển thị
            CreateMap<Author, AuthorSummaryModel>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ReverseMap();

            CreateMap<Author, AuthorDetailModel>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ReverseMap();
        }
    }
}
