using BookStore.DAL.Entities;
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
        public List<TagSummaryModel> GetAllDelete();
        public Task<List<TagSummaryModel>> GetAllDeleteAsync();
        public TagDetailModel? GetDetail(int TagId);
        public Task<TagDetailModel?> GetDetailAsync(int TagId);
        public Tag? GetTagByName(string TagName);
        public Task<Tag?> GetTagByNameAsync(string TagName);
        public List<TagDetailModel> GetListTagDetailByInfoId(int InfoId);
        public Task<List<TagDetailModel>> GetListTagDetailByInfoIdAsync(int InfoId);
    }
}
