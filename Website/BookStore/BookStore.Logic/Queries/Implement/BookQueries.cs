using AutoMapper;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Implement
{
    public class BookQueries : IBookQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public BookQueries(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public List<BookSummaryModel> GetAll()
        {
            return database.Books
                .Where(b => b.Status != Common.Shared.Model.Status.Delete)
                .Include(b => b.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.Edition)
                    .ThenInclude(e => e.EditionPublishers)
                        .ThenInclude(ep => ep.Publisher)
                .Include(b => b.Info)
                .Select(b => mapper.Map<BookSummaryModel>(b))
                .ToList();
        }

        public Task<List<BookSummaryModel>> GetAllAsync()
        {
            return database.Books
                .Where(b => b.Status != Common.Shared.Model.Status.Delete)
                .Include(b => b.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.Edition)
                    .ThenInclude(e => e.EditionPublishers)
                .Include(b => b.Info)
                .Select(b => mapper.Map<BookSummaryModel>(b))
                .ToListAsync();
        }

        public List<BookSummaryClientModel> GetAllClient()
        {
            return database.Books
                .Where(b => b.Status != Common.Shared.Model.Status.Delete)
                .Include(b => b.BookImages)
                .Include(b => b.Edition)
                .Include(b => b.Info)
                .Select(b => mapper.Map<BookSummaryClientModel>(b))
                .ToList();
        }

        public Task<List<BookSummaryClientModel>> GetAllClientAsync()
        {
            return database.Books
                .Where(b => b.Status != Common.Shared.Model.Status.Delete)
                .Include(b => b.BookImages)
                .Include(b => b.Edition)
                .Include(b => b.Info)
                .Select(b => mapper.Map<BookSummaryClientModel>(b))
                .ToListAsync();
        }

        public List<BookSummaryModel> GetAllDelete()
        {
            return database.Books
                .Where(b => b.Status == Common.Shared.Model.Status.Delete)
                .Include(b => b.BookImages)
                .Include(b => b.Edition)
                .Include(b => b.Info)
                .Select(b => mapper.Map<BookSummaryModel>(b))
                .ToList();
        }

        public Task<List<BookSummaryModel>> GetAllDeleteAsync()
        {
            return database.Books
                .Where(b => b.Status == Common.Shared.Model.Status.Delete)
                .Include(b => b.BookImages)
                .Include(b => b.Edition)
                .Include(b => b.Info)
                .Select(b => mapper.Map<BookSummaryModel>(b))
                .ToListAsync();
        }

        public BookDetailModel? GetDetail(int BookId)
        {
            return database.Books
                .Where(b => (b.Status != Common.Shared.Model.Status.Delete) && (b.BookId == BookId))
                .Include(b => b.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.Edition)
                    .ThenInclude(e => e.EditionPublishers)
                        .ThenInclude(ep => ep.Publisher)
                .Include(b => b.Info)
                .Include(b => b.Info.Series)
                .Select(b => mapper.Map<BookDetailModel>(b))
                .FirstOrDefault();
        }

        public Task<BookDetailModel?> GetDetailAsync(int BookId)
        {
                return database.Books
                .Where(b => b.Status != Common.Shared.Model.Status.Delete)
                .Include(b => b.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.Edition)
                    .ThenInclude(e => e.EditionPublishers)
                        .ThenInclude(ep => ep.Publisher)
                .Include(b => b.Info)
                .Include(b => b.Info.Series)
                .Select(b => mapper.Map<BookDetailModel>(b))
                .FirstOrDefaultAsync(b => b.BookId == BookId);
        }

        public BookDetailClientModel? GetDetailClient(int BookId)
        {
            return database.Books
                .Where(b => (b.Status != Common.Shared.Model.Status.Delete) && (b.BookId == BookId))
                .Include(b => b.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.Edition)
                    .ThenInclude(e => e.EditionPublishers)
                        .ThenInclude(ep => ep.Publisher)
                .Include(b => b.Info)
                    .ThenInclude(info => info.TagInfos)
                .Select(b => mapper.Map<BookDetailClientModel>(b))
                .FirstOrDefault();
        }

        public Task<BookDetailClientModel?> GetDetailClientAsync(int BookId)
        {
            return database.Books
               .Where(b => (b.Status != Common.Shared.Model.Status.Delete) && (b.BookId == BookId))
               .Include(b => b.AuthorBooks)
                   .ThenInclude(ab => ab.Author)
               .Include(b => b.Edition)
                   .ThenInclude(e => e.EditionPublishers)
                       .ThenInclude(ep => ep.Publisher)
               .Include(b => b.Info)
                    .ThenInclude(info => info.TagInfos)
               .Select(b => mapper.Map<BookDetailClientModel>(b))
               .FirstOrDefaultAsync();
        }

        public Book? GetBookByTitle(string Title)
        {
            return database.Books
               .Where(b => b.Status != Common.Shared.Model.Status.Delete)
               .Include(b => b.AuthorBooks)
                   .ThenInclude(ab => ab.Author)
               .Include(b => b.Edition)
                   .ThenInclude(e => e.EditionPublishers)
                       .ThenInclude(ep => ep.Publisher)
               .Include(b => b.Info)
                    .ThenInclude(info => info.TagInfos)
               .FirstOrDefault(b => b.Title == Title);
        }

        public Task<Book?> GetBookByTitleAsync(string Title)
        {
            return database.Books
               .Where(b => b.Status != Common.Shared.Model.Status.Delete)
               .Include(b => b.AuthorBooks)
                   .ThenInclude(ab => ab.Author)
               .Include(b => b.Edition)
                   .ThenInclude(e => e.EditionPublishers)
                       .ThenInclude(ep => ep.Publisher)
               .Include(b => b.Info)
                    .ThenInclude(info => info.TagInfos)
               .FirstOrDefaultAsync(b => b.Title == Title);
        }

        public Book? GetBookByISBN(string ISBN)
        {
            return database.Books
               .Where(b => b.Status != Common.Shared.Model.Status.Delete)
               .Include(b => b.AuthorBooks)
                   .ThenInclude(ab => ab.Author)
               .Include(b => b.Edition)
                   .ThenInclude(e => e.EditionPublishers)
                       .ThenInclude(ep => ep.Publisher)
               .Include(b => b.Info)
                    .ThenInclude(info => info.TagInfos)
               .FirstOrDefault(b => b.Edition.ISBN == ISBN);
        }

        public Task<Book?> GetBookByISBNAsync(string ISBN)
        {
            return database.Books
               .Where(b => b.Status != Common.Shared.Model.Status.Delete)
               .Include(b => b.AuthorBooks)
                   .ThenInclude(ab => ab.Author)
               .Include(b => b.Edition)
                   .ThenInclude(e => e.EditionPublishers)
                       .ThenInclude(ep => ep.Publisher)
               .Include(b => b.Info)
                    .ThenInclude(info => info.TagInfos)
               .FirstOrDefaultAsync(b => b.Edition.ISBN == ISBN);
        }
    }
}
