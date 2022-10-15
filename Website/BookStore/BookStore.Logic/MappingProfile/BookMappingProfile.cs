using AutoMapper;
using BookStore.Logic.Shared.Model;
using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.MappingProfile
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookSummaryClientModel>()
                .ForMember(dest => dest.DiscountPercent, opt => opt.MapFrom(src => src.Info.DiscountPercent))
                .ForMember(dest => dest.VolumeNumber, opt => opt.MapFrom(src => src.Info.VolumeNumber))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Info.Tags))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Edition.Price))
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.Edition.Price - (src.Edition.Price * (src.Info.DiscountPercent / 100))))
                .ForMember(dest => dest.Format, opt => opt.MapFrom(src => src.Edition.Format))
                .ForMember(dest => dest.PrintRunSize, opt => opt.MapFrom(src => src.Edition.PrintRunSize))
                .ForMember(dest => dest.Pages, opt => opt.MapFrom(src => src.Edition.Pages))
                .ForMember(dest => dest.PulishingHouse, opt => opt.MapFrom(src => src.Edition.EditionPublishers
                    .Where(e => e.EditionId == src.Edition.EditionId)
                    .Select(e => e.Publisher.PulishingHouse)
                    .FirstOrDefault()))
                .ReverseMap();
        }
    }
}
