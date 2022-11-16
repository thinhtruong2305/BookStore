using AutoMapper;
using BookStore.Common.Shared.Model;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                .Include(b => b.BookImages)
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

        public Book? GetBookByTitleAndVolumNumber(string Title, int volume)
        {
            return database.Books
               .Where(b => b.Status != Common.Shared.Model.Status.Delete)
               .Include(b => b.AuthorBooks)
               .Include(b => b.Edition)
               .Include(b => b.Info)
               .Include(b => b.BookImages)
               .Include(b => b.Category)
               .FirstOrDefault(b => b.Title == Title && b.Info.VolumeNumber == volume);
        }

        public Task<Book?> GetBookByTitleAndVolumNumberAsync(string Title, int volume)
        {
            return database.Books
               .Where(b => b.Status != Common.Shared.Model.Status.Delete)
               .FirstOrDefaultAsync(b => b.Title == Title && b.Info.VolumeNumber == volume);
        }

        public BasePaging<BookSummaryClientModel> GetAllClientPaging(BaseQuery query)
        {
            var books = database.Books.
                Where(b => (b.Title!.Contains(query.Keywords ?? string.Empty) ||
                            b.Decription!.Contains(query.Keywords ?? string.Empty)) &&
                b.Status != Status.Delete)
            .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
            .Select(x => mapper.Map<BookSummaryClientModel>(x))
            .ToList();
            var postCount = database.Books.Count();

            return new BasePaging<BookSummaryClientModel>()
            {
                Items = books,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = postCount,
                TotalPage = (int)Math.Ceiling((double)postCount / (query.PageSize ?? 20))
            };
        }

        public Task<BasePaging<BookSummaryClientModel>> GetAllClientPagingAsync(BaseQuery query)
        {
            var books = database.Books.
                Where(b => (b.Title!.Contains(query.Keywords ?? string.Empty) ||
                            b.Decription!.Contains(query.Keywords ?? string.Empty)) &&
                b.Status != Status.Delete)
            .Skip(((query.PageIndex - 1) * query.PageSize) ?? 0).Take((query.PageSize * query.PageIndex) ?? 20)
            .Select(x => mapper.Map<BookSummaryClientModel>(x))
            .ToList();
            var postCount = database.Books.Count();

            return Task.FromResult(new BasePaging<BookSummaryClientModel>()
            {
                Items = books,
                PageSize = query.PageSize ?? 1,
                PageIndex = query.PageIndex ?? 20,
                TotalItem = postCount,
                TotalPage = (int)Math.Ceiling((double)postCount / (query.PageSize ?? 20))
            });
        }
    }
}
