using AutoMapper;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Queries.Interface;
using BookStore.Logic.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<BookSummaryClientModel> GetAllClient()
        
        
        {
            return database.Books
                .Where(b => b.Status != Common.Shared.Model.Status.Delete)
                .Include(b => b.AuthorBooks)
                    .ThenInclude(ab => ab.Author)
                .Include(b => b.Edition)
                    .ThenInclude(e => e.EditionPublishers)
                        .ThenInclude(ep => ep.Publisher)
                .Include(b => b.Info)
                .Include(b => b.Info.Tags)
                .Select(b => mapper.Map<BookSummaryClientModel>(b))
                .ToList();
        }

        public Task<List<BookSummaryClientModel>> GetAllClientAsync()
        {
            throw new NotImplementedException();
        }
    }
}
