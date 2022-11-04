using AutoMapper;
using BookStore.DAL;
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
                .Where(a => a.Status != Common.Shared.Model.Status.Delete)
                .Select(a => mapper.Map<AuthorDetailModel>(a))
                .FirstOrDefault(a => a.AuthorId == AuthorId);
        }

        public Task<AuthorDetailModel?> GetDetailAsync(int AuthorId)
        {
            return database.Authors
                .Where(a => a.Status != Common.Shared.Model.Status.Delete)
                .Select(a => mapper.Map<AuthorDetailModel>(a))
                .FirstOrDefaultAsync(a => a.AuthorId == AuthorId);
        }
    }
}
