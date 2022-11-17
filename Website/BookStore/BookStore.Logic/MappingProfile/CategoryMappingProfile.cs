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
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            //Map cho phần hiển thị
            CreateMap<Category, CategorySummaryModel>()
                .ReverseMap();

            CreateMap<Category, CategoryDetailModel>()
                .ReverseMap();

            //Map phần này cho phần Create Update Delete
            //Create
            CreateMap<CreateCategoryRequest, Category>();

            //Update
            CreateMap<UpdateCategoryRequest, Category>();

            //Delete
            CreateMap<DeleteCategoryRequest, Category>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
