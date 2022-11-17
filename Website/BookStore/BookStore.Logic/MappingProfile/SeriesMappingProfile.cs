using AutoMapper;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
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
            //Map này cho phần hiển thị
            CreateMap<Series, SeriesSummaryModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.info.Book.Title))
                .ForMember(dest => dest.VolumeNumber, opt => opt.MapFrom(src => src.info.VolumeNumber))
                .ForMember(dest => dest.AuthorBooks, opt => opt.MapFrom(src => src.info.Book.AuthorBooks))
                .ReverseMap();

            CreateMap<Series, SeriesDetailModel>()
                .ForMember(dest => dest.AuthorBooks, opt => opt.MapFrom(src => src.info.Book.AuthorBooks))
                .ReverseMap();

            //Map phần này cho phần Create Update Delete
            //Create
            CreateMap<CreateSeriesRequest, Series>();

            //Update
            CreateMap<UpdateSeriesRequest, Series>();

            //Delete
            CreateMap<DeleteSeriesRequest, Series>()
                .ForMember(dest => dest.SeriesId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
