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
    public class CategoryQueries : ICategoryQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CategoryQueries(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public List<CategorySummaryModel> GetAll()
        {
            return database.Categories
                .Where(c => c.Status != Common.Shared.Model.Status.Delete)
                .Select(c => mapper.Map<CategorySummaryModel>(c))
                .ToList();
        }

        public Task<List<CategorySummaryModel>> GetAllAsync()
        {
            return database.Categories
                .Where(c => c.Status != Common.Shared.Model.Status.Delete)
                .Select(c => mapper.Map<CategorySummaryModel>(c))
                .ToListAsync();
        }

        public List<CategorySummaryModel> GetAllDelete()
        {
            return database.Categories
                .Where(c => c.Status == Common.Shared.Model.Status.Delete)
                .Select(c => mapper.Map<CategorySummaryModel>(c))
                .ToList();
        }

        public Task<List<CategorySummaryModel>> GetAllDeleteAsync()
        {
            return database.Categories
                .Where(c => c.Status == Common.Shared.Model.Status.Delete)
                .Select(c => mapper.Map<CategorySummaryModel>(c))
                .ToListAsync();
        }

        public CategoryDetailModel? GetDetail(int CategoryId)
        {
            return database.Categories
                .Where(c => (c.Status != Common.Shared.Model.Status.Delete) && (c.CategoryId == CategoryId))
                .Select(c => mapper.Map<CategoryDetailModel>(c))
                .FirstOrDefault();
        }

        public Task<CategoryDetailModel?> GetDetailAsync(int CategoryId)
        {
            return database.Categories
                .Where(c => (c.Status != Common.Shared.Model.Status.Delete) && (c.CategoryId == CategoryId))
                .Select(c => mapper.Map<CategoryDetailModel>(c))
                .FirstOrDefaultAsync();
        }
    }
}
