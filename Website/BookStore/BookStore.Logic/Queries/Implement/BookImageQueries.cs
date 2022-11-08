using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Queries.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Implement
{
    public class BookImageQueries : IBookImageQueries
    {
        private readonly AppDatabase database;

        public BookImageQueries(AppDatabase database)
        {
            this.database = database;
        }
        public BookImage? GetBookImageById(int id)
        {
            return database.BookImages
                .FirstOrDefault(bi => bi.BookImageId == id);
        }

        public Task<BookImage?> GetBookImageByIdAsync(int id)
        {
            return database.BookImages
                .FirstOrDefaultAsync(bi => bi.BookImageId == id);
        }

        public List<BookImage> GetListBookImageByBookId(int BookId)
        {
            return database.BookImages
                .Where(bi => (bi.Status != Common.Shared.Model.Status.Delete) && (bi.BookId == BookId))
                .ToList();
        }

        public Task<List<BookImage>> GetListBookImageByBookIdAsync(int BookId)
        {
            return database.BookImages
                .Where(bi => (bi.Status != Common.Shared.Model.Status.Delete) && (bi.BookId == BookId))
                .ToListAsync();
        }
    }
}
