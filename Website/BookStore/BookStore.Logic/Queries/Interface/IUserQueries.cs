using BookStore.Logic.Shared.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Interface
{
    public interface IUserQueries
    {
        public List<UserSummaryModel> GetAll();
        public Task<List<UserSummaryModel>> GetAllAsync();
        public UserDetailModel GetDetail(string Userid);
        public Task<UserDetailModel> GetDetailAsync(string Userid);
    }
}
