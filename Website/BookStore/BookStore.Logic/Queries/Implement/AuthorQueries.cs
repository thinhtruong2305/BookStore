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
    public class AuthorQueries : IAuthorQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public AuthorQueries(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public List<AuthorSummaryModel> GetAll()
        {
            return database.Authors
                .Where(a => a.Status != Common.Shared.Model.Status.Delete)
                .Select(a => mapper.Map<AuthorSummaryModel>(a))
                .ToList();
        }

        public Task<List<AuthorSummaryModel>> GetAllAsync()
        {
            return database.Authors
                .Where(a => a.Status != Common.Shared.Model.Status.Delete)
                .Select(a => mapper.Map<AuthorSummaryModel>(a))
                .ToListAsync();
        }

        public List<AuthorSummaryModel> GetAllDelete()
        {
            return database.Authors
                .Where(a => a.Status == Common.Shared.Model.Status.Delete)
                .Select(a => mapper.Map<AuthorSummaryModel>(a))
                .ToList();
        }

        public Task<List<AuthorSummaryModel>> GetAllDeleteAsync()
        {
            return database.Authors
                .Where(a => a.Status == Common.Shared.Model.Status.Delete)
                .Select(a => mapper.Map<AuthorSummaryModel>(a))
                .ToListAsync();
        }

        public AuthorDetailModel? GetDetail(int AuthorId)
        {
            return database.Authors
                .Where(a => (a.Status != Common.Shared.Model.Status.Delete) && (a.AuthorId == AuthorId))
                .Select(a => mapper.Map<AuthorDetailModel>(a))
                .FirstOrDefault();
        }

        public Task<AuthorDetailModel?> GetDetailAsync(int AuthorId)
        {
            return database.Authors
                .Where(a => (a.Status != Common.Shared.Model.Status.Delete) && (a.AuthorId == AuthorId))
                .Select(a => mapper.Map<AuthorDetailModel>(a))
                .FirstOrDefaultAsync();
        }

        public Author? GetAuthorByName(string FirstName, string LastName)
        {
            return database.Authors
                .Where(a => a.Status != Common.Shared.Model.Status.Delete)
                .FirstOrDefault(a => a.FirstName.ToLower() == FirstName.ToLower() &&
                a.LastName.ToLower() == LastName.ToLower());
        }

        public Task<Author?> GetAuthorByNameAsync(string FirstName, string LastName)
        {
            return database.Authors
                .Where(a => a.Status != Common.Shared.Model.Status.Delete)
                .FirstOrDefaultAsync(a => a.FirstName.ToLower() == FirstName.ToLower() &&
                a.LastName.ToLower() == LastName.ToLower());
        }

        public List<AuthorDetailModel> GetAuthorDetailModelByBookId(int BookId)
        {
            return database.AuthorBooks
                .Where(ab => ab.BookId == BookId)
                .Select(ab => mapper.Map<AuthorDetailModel>(ab.Author))
                .ToList();
        }

        public Task<List<AuthorDetailModel>> GetAuthorDetailModelByBookIdAsync(int BookId)
        {
            return database.AuthorBooks
                .Where(ab => ab.BookId == BookId)
                .Select(ab => mapper.Map<AuthorDetailModel>(ab.Author))
                .ToListAsync();
        }
    }
}
