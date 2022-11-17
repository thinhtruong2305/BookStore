using BookStore.Logic.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Interface
{
    public interface ICategoryQueries
    {
        public List<CategorySummaryModel> GetAll();
        public Task<List<CategorySummaryModel>> GetAllAsync();
        public List<CategorySummaryModel> GetAllDelete();
        public Task<List<CategorySummaryModel>> GetAllDeleteAsync();
        public CategoryDetailModel? GetDetail(int CategoryId);
        public Task<CategoryDetailModel?> GetDetailAsync(int CategoryId);
    }
}
