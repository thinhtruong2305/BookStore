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
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            //Map cho phần hiển thị
            CreateMap<Tag, TagSummaryModel>()
                .ReverseMap();
            CreateMap<Tag, TagDetailModel>()
                .ReverseMap();
        }
    }
}
