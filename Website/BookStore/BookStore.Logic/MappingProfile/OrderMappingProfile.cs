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
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderSummaryModel>()
                .ReverseMap();
            CreateMap<Order, OrderDetailModel>()
                .ReverseMap();
        }
    }
}
