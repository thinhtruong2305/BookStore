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
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            //Map cho phần hiển thị
            CreateMap<Tag, TagSummaryModel>()
                .ReverseMap();
            CreateMap<Tag, TagDetailModel>()
                .ReverseMap();
            //Map phần này cho phần Create Update Delete
            //Create
            CreateMap<CreateTagRequest, Tag>();

            //Update
            CreateMap<UpdateTagRequest, Tag>();

            //Delete
            CreateMap<DeleteTagRequest, Tag>()
                .ForMember(dest => dest.TagId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
