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
    public class MenuMappingProfile : Profile
    {
        public MenuMappingProfile()
        {
            //Map cho phần hiển thị
            CreateMap<Menu, MenuSummaryModel>()
                .ReverseMap();
            CreateMap<Menu, MenuDetailModel>()
                .ReverseMap();
        }
    }
}
