using AutoMapper;
using BookStore.DAL.Entities;
using BookStore.Logic.Shared.Model;

namespace BookStore.Website.Models.MappingProfile
{
    public class OrderSenderMappingProfile : Profile
    {
        public OrderSenderMappingProfile()
        {
            CreateMap<OrderDetailModel, OrderSenderModel>()
                .ReverseMap();
        }
    }
}
