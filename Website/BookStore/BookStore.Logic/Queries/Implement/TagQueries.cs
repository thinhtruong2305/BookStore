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
    public class TagQueries : ITagQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public TagQueries(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public List<TagSummaryModel> GetAll()
        {
            return database.Tags
                .Where(t => t.Status != Common.Shared.Model.Status.Delete)
                .Select(t => mapper.Map<TagSummaryModel>(t))
                .ToList();
        }

        public Task<List<TagSummaryModel>> GetAllAsync()
        {
            return database.Tags
                .Where(t => t.Status != Common.Shared.Model.Status.Delete)
                .Select(t => mapper.Map<TagSummaryModel>(t))
                .ToListAsync();
        }

        public TagDetailModel GetDetail(int TagId)
        {
            return database.Tags
                .Where(t => (t.Status != Common.Shared.Model.Status.Delete) && (t.TagId == TagId))
                .Select(t => mapper.Map<TagDetailModel>(t))
                .First();
        }

        public Task<TagDetailModel> GetDetailAsync(int TagId)
        {
            return database.Tags
                .Where(t => (t.Status != Common.Shared.Model.Status.Delete) && (t.TagId == TagId))
                .Select(t => mapper.Map<TagDetailModel>(t))
                .FirstAsync();
        }
    }
}
