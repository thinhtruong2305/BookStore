using AutoMapper;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.MappingProfile
{
    public class OrderDetailMappingProfile : Profile
    {
        public OrderDetailMappingProfile()
        {
            //Map phần này cho phần Create Update Delete
            //Create
            CreateMap<CreateOrderDetailRequest, OrderDetail>();

            //Update
            CreateMap<UpdateOrderDetailRequest, OrderDetail>();

            //Delete
            CreateMap<DeleteOrderDetailRequest, OrderDetail>()
                .ForMember(dest => dest.OrderDetailId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
