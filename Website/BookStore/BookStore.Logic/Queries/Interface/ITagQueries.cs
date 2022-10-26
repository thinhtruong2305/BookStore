using BookStore.Logic.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Interface
{
    public interface ITagQueries
    {
        public List<TagSummaryModel> GetAll();
        public Task<List<TagSummaryModel>> GetAllAsync();
        public TagDetailModel GetDetail(int TagId);
        public Task<TagDetailModel> GetDetailAsync(int TagId);
    }
}
