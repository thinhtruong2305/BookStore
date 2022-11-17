using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Interface
{
    public interface IBookImageQueries
    {
        public BookImage? GetBookImageById(int id);
        public Task<BookImage?> GetBookImageByIdAsync(int id);
        public List<BookImage> GetListBookImageByBookId(int BookId);
        public Task<List<BookImage>> GetListBookImageByBookIdAsync(int BookId);
    }
}
