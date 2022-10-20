using BookStore.Logic.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Interface
{
    /// <summary>
    /// Phần này dùng để hiển thị
    /// </summary>
    public interface IBookQueries
    {
        public List<BookSummaryClientModel> GetAllClient();
        public Task<List<BookSummaryClientModel>> GetAllClientAsync();
        public BookDetailClientModel GetDetailClient(int BookId);
        public Task<BookDetailClientModel> GetDetailClientAsync(int BookId);
        public List<BookSummaryModel> GetAll();
        public Task<List<BookSummaryModel>> GetAllAsync();
        public BookDetailModel GetDetail(int BookId);
        public Task<BookDetailModel> GetDetailAsync(int BookId);
    }
}
