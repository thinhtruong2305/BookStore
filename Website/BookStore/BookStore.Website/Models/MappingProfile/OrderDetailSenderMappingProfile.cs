using AutoMapper;
using BookStore.DAL.Entities;

namespace BookStore.Website.Models.MappingProfile
{
    public class OrderDetailSenderMappingProfile : Profile
    {
        public OrderDetailSenderMappingProfile()
        {
            CreateMap<OrderDetail, OrderDetailSenderModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Book.Edition.Price - ((src.Book.Edition.Price * src.Book.Info.DiscountPercent) / 100)))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => src.Payment))
                .ReverseMap();
        }
    }
}
