using BookStore.Logic.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Interface
{
    public interface IMenuQueries
    {
        public List<MenuSummaryModel> GetAll();
        public Task<List<MenuSummaryModel>> GetAllAsync();
        public MenuDetailModel GetDetail(int MenuId);
        public Task<MenuDetailModel> GetDetailAsync(int MenuId);
    }
}
