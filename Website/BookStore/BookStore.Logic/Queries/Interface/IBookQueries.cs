using BookStore.Common.Shared.Model;
using BookStore.DAL.Entities;
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
        public BasePaging<BookSummaryClientModel> GetAllClientPaging(BaseQuery query);
        public Task<BasePaging<BookSummaryClientModel>> GetAllClientPagingAsync(BaseQuery query);
        public BookDetailClientModel? GetDetailClient(int BookId);
        public Task<BookDetailClientModel?> GetDetailClientAsync(int BookId);
        public List<BookSummaryModel> GetAll();
        public Task<List<BookSummaryModel>> GetAllAsync();
        public List<BookSummaryModel> GetAllDelete();
        public Task<List<BookSummaryModel>> GetAllDeleteAsync();
        public BookDetailModel? GetDetail(int BookId);
        public Task<BookDetailModel?> GetDetailAsync(int BookId);
        public Book? GetBookByTitle(string Title);
        public Task<Book?> GetBookByTitleAsync(string Title);
        public Book? GetBookByTitleAndVolumNumber(string Title, int volume);
        public Task<Book?> GetBookByTitleAndVolumNumberAsync(string Title, int volume);
        public Book? GetBookByISBN(string ISBN);
        public Task<Book?> GetBookByISBNAsync(string ISBN);
    }
}
