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
    public class PublisherQueries : IPublisherQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public PublisherQueries(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public List<PublisherSummaryModel> GetAll()
        {
            return database.Publishers
                .Where(p => p.Status != Common.Shared.Model.Status.Delete)
                .Select(p => mapper.Map<PublisherSummaryModel>(p))
                .ToList();
        }

        public Task<List<PublisherSummaryModel>> GetAllAsync()
        {
            return database.Publishers
                .Where(p => p.Status != Common.Shared.Model.Status.Delete)
                .Select(p => mapper.Map<PublisherSummaryModel>(p))
                .ToListAsync();
        }

        public List<PublisherSummaryModel> GetAllDelete()
        {
            return database.Publishers
                .Where(p => p.Status == Common.Shared.Model.Status.Delete)
                .Select(p => mapper.Map<PublisherSummaryModel>(p))
                .ToList();
        }

        public Task<List<PublisherSummaryModel>> GetAllDeleteAsync()
        {
            return database.Publishers
                .Where(p => p.Status == Common.Shared.Model.Status.Delete)
                .Select(p => mapper.Map<PublisherSummaryModel>(p))
                .ToListAsync();
        }

        public PublisherDetailModel? GetDetail(int PublisherId)
        {
            return database.Publishers
                .Where(p => p.Status != Common.Shared.Model.Status.Delete)
                .Include(p => p.EditionPublishers)
                    .ThenInclude(ep => ep.Edition)
                .Select(o => mapper.Map<PublisherDetailModel>(o))
                .FirstOrDefault(p => p.PublisherId == PublisherId);
        }

        public Task<PublisherDetailModel?> GetDetailAsync(int PublisherId)
        {
            return database.Publishers
                .Where(p => p.Status != Common.Shared.Model.Status.Delete)
                .Include(p => p.EditionPublishers)
                    .ThenInclude(ep => ep.Edition)
                .Select(o => mapper.Map<PublisherDetailModel>(o))
                .FirstOrDefaultAsync(p => p.PublisherId == PublisherId);
        }
    }
}
