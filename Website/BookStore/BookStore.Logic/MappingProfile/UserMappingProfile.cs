using BookStore.DAL.Entities;
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
            CreateMap<User, UserSummaryModel>()
                .ReverseMap();
            CreateMap<User, UserSummaryModel>()
                .ReverseMap();
        }
    }
}
