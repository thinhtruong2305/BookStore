using AutoMapper;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Implement
{
    public class UserQueries : IUserQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UserQueries(AppDatabase database, 
            IMapper mapper, 
            UserManager<User> userManager)
        {
            this.database = database;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public List<UserSummaryModel> GetAll()
        {
            return userManager.Users
                .Select(u => mapper.Map<UserSummaryModel>(u))
                .ToList();
        }

        public Task<List<UserSummaryModel>> GetAllAsync()
        {
            return Task.Run(() => userManager.Users
                 .Select(u => mapper.Map<UserSummaryModel>(u))
                 .ToListAsync());
        }

        public UserDetailModel? GetDetail(string UserId)
        {
            return userManager.Users
                .Where(u => u.Id == UserId)
                .Select(u => mapper.Map<UserDetailModel>(u))
                .FirstOrDefault();
        }

        public Task<UserDetailModel?> GetDetailAsync(string UserId)
        {
            return userManager.Users
                .Where(u => u.Id == UserId)
                .Select(u => mapper.Map<UserDetailModel>(u))
                .FirstOrDefaultAsync();
        }
    }
}
