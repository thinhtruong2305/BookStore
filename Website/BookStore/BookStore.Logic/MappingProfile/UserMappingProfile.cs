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
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            //Map này cho phần hiển thị
            CreateMap<User, UserSummaryModel>()
                .ReverseMap();
            CreateMap<User, UserSummaryModel>()
                .ReverseMap();

            //Map phần này cho phần Create Update Delete
            //Create
            CreateMap<CreateUserRequest, User>();

            //Update
            CreateMap<UpdateUserRequest, User>();

            //Delete
            CreateMap<DeleteUserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
