using BookStore.Logic.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Interface
{
    public interface IAuthorQueries
    {
        public List<AuthorSummaryModel> GetAll();
        public Task<List<AuthorSummaryModel>> GetAllAsync();
        public AuthorDetailModel GetDetail(int AuthorId);
        public Task<AuthorDetailModel> GetDetailAsync(int AuthorId);
    }
}
