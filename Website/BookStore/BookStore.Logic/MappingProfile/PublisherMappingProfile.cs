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
    public class PublisherMappingProfile : Profile
    {
        public PublisherMappingProfile()
        {
            //Map này cho phần hiển thị
            CreateMap<Publisher, PublisherSummaryModel>()
                .ReverseMap();
            CreateMap<Publisher, PublisherDetailModel>()
                .ReverseMap();
            //Map phần này cho phần Create Update Delete
            //Create
            CreateMap<CreatePublisherRequest, Publisher>();

            //Update
            CreateMap<UpdatePublisherRequest, Publisher>();

            //Delete
            CreateMap<DeletePublisherRequest, Publisher>()
                .ForMember(dest => dest.PublisherId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
