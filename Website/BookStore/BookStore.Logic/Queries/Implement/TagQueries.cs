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

        public List<TagSummaryModel> GetAllDelete()
        {
            return database.Tags
                .Where(t => t.Status == Common.Shared.Model.Status.Delete)
                .Select(t => mapper.Map<TagSummaryModel>(t))
                .ToList();
        }

        public Task<List<TagSummaryModel>> GetAllDeleteAsync()
        {
            return database.Tags
                .Where(t => t.Status == Common.Shared.Model.Status.Delete)
                .Select(t => mapper.Map<TagSummaryModel>(t))
                .ToListAsync();
        }

        public TagDetailModel? GetDetail(int TagId)
        {
            return database.Tags
                .Where(t => (t.Status != Common.Shared.Model.Status.Delete) && (t.TagId == TagId))
                .Select(t => mapper.Map<TagDetailModel>(t))
                .FirstOrDefault();
        }

        public Task<TagDetailModel?> GetDetailAsync(int TagId)
        {
            return database.Tags
                .Where(t => t.Status != Common.Shared.Model.Status.Delete)
                .Select(t => mapper.Map<TagDetailModel>(t))
                .FirstOrDefaultAsync(t => t.TagId == TagId);
        }

        public List<TagDetailModel> GetListTagDetailByInfoId(int InfoId)
        {
            return database.TagInfos
                .Where(ti => (ti.Tag.Status != Common.Shared.Model.Status.Delete) && (ti.InfoId == InfoId))
                .Select(ti => mapper.Map<TagDetailModel>(ti.Tag))
                .ToList();
        }

        public Task<List<TagDetailModel>> GetListTagDetailByInfoIdAsync(int InfoId)
        {
            return database.TagInfos
                .Where(ti => (ti.Tag.Status != Common.Shared.Model.Status.Delete) && (ti.InfoId == InfoId))
                .Select(ti => mapper.Map<TagDetailModel>(ti.Tag))
                .ToListAsync();
        }

        public Tag? GetTagByName(string TagName)
        {
            return database.Tags.Where(t => t.Status != Common.Shared.Model.Status.Delete)
                .FirstOrDefault(t => t.TagName == TagName);
        }

        public Task<Tag?> GetTagByNameAsync(string TagName)
        {
            return database.Tags.Where(t => t.Status != Common.Shared.Model.Status.Delete)
                .FirstOrDefaultAsync(t => t.TagName == TagName);
        }
    }
}
