using BookStore.DAL.Entities;
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
        public List<AuthorSummaryModel> GetAllDelete();
        public Task<List<AuthorSummaryModel>> GetAllDeleteAsync();
        public AuthorDetailModel? GetDetail(int AuthorId);
        public Task<AuthorDetailModel?> GetDetailAsync(int AuthorId);
        public Author? GetAuthorByName(string FirstName, string LastName);
        public Task<Author?> GetAuthorByNameAsync(string FirstName, string LastName);
        public List<AuthorDetailModel> GetAuthorDetailModelByBookId(int BookId);
        public Task<List<AuthorDetailModel>> GetAuthorDetailModelByBookIdAsync(int BookId);
    }
}
