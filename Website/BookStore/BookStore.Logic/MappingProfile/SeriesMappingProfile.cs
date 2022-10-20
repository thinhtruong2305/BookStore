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
    public class SeriesMappingProfile : Profile
    {
        public SeriesMappingProfile()
        {
            CreateMap<Series, SeriesSummaryModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.info.Book.Title))
                .ForMember(dest => dest.VolumeNumber, opt => opt.MapFrom(src => src.info.VolumeNumber))
                .ForMember(dest => dest.AuthorBooks, opt => opt.MapFrom(src => src.info.Book.AuthorBooks))
                .ReverseMap();

            CreateMap<Series, SeriesDetailModel>()
                .ForMember(dest => dest.AuthorBooks, opt => opt.MapFrom(src => src.info.Book.AuthorBooks))
                .ReverseMap();
        }
    }
}
