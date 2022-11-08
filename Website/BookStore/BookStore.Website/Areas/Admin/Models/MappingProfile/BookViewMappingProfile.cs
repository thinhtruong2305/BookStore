using AutoMapper;
using BookStore.Logic.Shared.Model;

namespace BookStore.Website.Areas.Admin.Models.MappingProfile
{
    public class BookViewMappingProfile : Profile
    {
        public BookViewMappingProfile()
        {
            CreateMap<BookDetailModel, BookViewModel>()
                .ForPath(dest => dest.InfoViewModel.InfoId, opt => opt.MapFrom(src => src.Info.InfoId))
                .ForPath(dest => dest.InfoViewModel.VolumeNumber, opt => opt.MapFrom(src => src.Info.VolumeNumber))
                .ForPath(dest => dest.InfoViewModel.DiscountPercent, opt => opt.MapFrom(src => src.Info.DiscountPercent))
                .ForPath(dest => dest.InfoViewModel.Language, opt => opt.MapFrom(src => src.Info.Language))
                .ForPath(dest => dest.EditionViewModel.EditionId, opt => opt.MapFrom(src => src.Edition.EditionId))
                .ForPath(dest => dest.EditionViewModel.Format, opt => opt.MapFrom(src => src.Edition.Format))
                .ForPath(dest => dest.EditionViewModel.PrintRunSize, opt => opt.MapFrom(src => src.Edition.PrintRunSize))
                .ForPath(dest => dest.EditionViewModel.Pages, opt => opt.MapFrom(src => src.Edition.Pages))
                .ForPath(dest => dest.EditionViewModel.ISBN, opt => opt.MapFrom(src => src.Edition.ISBN))
                .ForPath(dest => dest.EditionViewModel.PublicationDate, opt => opt.MapFrom(src => src.Edition.PublicationDate))
                .ForPath(dest => dest.EditionViewModel.Price, opt => opt.MapFrom(src => src.Edition.Price))
                .ForPath(dest => dest.SeriesViewModel.SeriesName, opt => opt.MapFrom(src => src.Series.SeriesName))
                .ForPath(dest => dest.SeriesViewModel.SeriesId, opt => opt.MapFrom(src => src.Series.SeriesId))
                .ForPath(dest => dest.SeriesViewModel.PlannedVolume, opt => opt.MapFrom(src => src.Series.PlannedVolume))
                .ReverseMap();
        }
    }
}
