using AutoMapper;
using BookStore.Logic.Shared.Model;
using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Logic.Command.Request;

namespace BookStore.Logic.MappingProfile
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            //Map cho phần hiển thị
            CreateMap<Book, BookSummaryClientModel>()
                .ForMember(dest => dest.DiscountPercent, opt => opt.MapFrom(src => src.Info.DiscountPercent))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Edition.Price))
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.Edition.Price - ((src.Edition.Price * src.Info.DiscountPercent) / 100)))
                .ReverseMap();

            CreateMap<Book, BookSummaryModel>()
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.Edition.ISBN))
                .ForMember(dest => dest.VolumeNumber, opt => opt.MapFrom(src => src.Info.VolumeNumber))
                .ForMember(dest => dest.Pulisher, opt => opt.MapFrom(src => src.Edition.EditionPublishers))
                .ReverseMap();

            CreateMap<Book, BookDetailClientModel>()
                .ForMember(dest => dest.DiscountPercent, opt => opt.MapFrom(src => src.Info.DiscountPercent))
                .ForMember(dest => dest.VolumeNumber, opt => opt.MapFrom(src => src.Info.VolumeNumber))
                .ForMember(dest => dest.TagInfos, opt => opt.MapFrom(src => src.Info.TagInfos))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Edition.Price))
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.Edition.Price - ((src.Edition.Price * src.Info.DiscountPercent) / 100)))
                .ForMember(dest => dest.Format, opt => opt.MapFrom(src => src.Edition.Format))
                .ForMember(dest => dest.PrintRunSize, opt => opt.MapFrom(src => src.Edition.PrintRunSize))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Info.Language))
                .ForMember(dest => dest.PublicationDate, opt => opt.MapFrom(src => src.Edition.PublicationDate))
                .ForMember(dest => dest.Pages, opt => opt.MapFrom(src => src.Edition.Pages))
                .ForMember(dest => dest.EditionPublisher, opt => opt.MapFrom(src => src.Edition.EditionPublishers))
                .ReverseMap();

            CreateMap<Book, BookDetailModel>()
                .ForMember(dest => dest.Series, opt => opt.MapFrom(src => src.Info.Series))
                .ForMember(dest => dest.TagInfos, opt => opt.MapFrom(src => src.Info.TagInfos))
                .ForMember(dest => dest.EditionPulisher, opt => opt.MapFrom(src => src.Edition.EditionPublishers))
                .ForMember(dest => dest.AuthorBooks, opt => opt.MapFrom(src => src.AuthorBooks))
                .ReverseMap();

            //Map phần này cho phần Create Update Delete
            //Create
            CreateMap<CreateBookRequest, Book>();

            //Update
            CreateMap<UpdateBookRequest, Book>();

            //Delete
            CreateMap<DeleteBookRequest, Book>()
                .ForMember(dest => dest.BookId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
