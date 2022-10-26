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
    public class PublisherMappingProfile : Profile
    {
        public PublisherMappingProfile()
        {
            new BookMappingProfile();

            //Map này cho phần hiển thị
            CreateMap<Publisher, PublisherSummaryModel>()
                .ReverseMap();
            CreateMap<Publisher, PublisherDetailModel>()
                .ReverseMap();
        }
    }
}
