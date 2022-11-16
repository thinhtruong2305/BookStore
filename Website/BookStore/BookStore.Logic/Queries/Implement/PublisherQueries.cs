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
                .Where(p => (p.Status != Common.Shared.Model.Status.Delete) && (p.PublisherId == PublisherId))
                .Include(p => p.EditionPublishers)
                    .ThenInclude(ep => ep.Edition)
                .Select(o => mapper.Map<PublisherDetailModel>(o))
                .FirstOrDefault();
        }

        public Task<PublisherDetailModel?> GetDetailAsync(int PublisherId)
        {
            return database.Publishers
                .Where(p => (p.Status != Common.Shared.Model.Status.Delete) && (p.PublisherId == PublisherId))
                .Include(p => p.EditionPublishers)
                    .ThenInclude(ep => ep.Edition)
                .Select(o => mapper.Map<PublisherDetailModel>(o))
                .FirstOrDefaultAsync(p => p.PublisherId == PublisherId);
        }

        public List<PublisherDetailModel> GetListPublisherDetailByEditionId(int EditionId)
        {
            return database.EditionPublishers
                .Where(ep => ep.EditionId == EditionId)
                .Select(ep => mapper.Map<PublisherDetailModel>(ep.Publisher))
                .ToList();
        }

        public Task<List<PublisherDetailModel>> GetListPublisherDetailByEditionIdAsync(int EditionId)
        {
            return database.EditionPublishers
                .Where(ep => ep.EditionId == EditionId)
                .Select(ep => mapper.Map<PublisherDetailModel>(ep.Publisher))
                .ToListAsync();
        }

        public Publisher? GetPublisherByPulishingHouse(string PublishingHouse)
        {
            return database.Publishers
                .Where(p => p.Status != Common.Shared.Model.Status.Delete)
                .FirstOrDefault(p => p.PulishingHouse == PublishingHouse);
        }

        public Task<Publisher?> GetPublisherByPulishingHouseAsync(string PublishingHouse)
        {
            return database.Publishers
                .Where(p => p.Status != Common.Shared.Model.Status.Delete)
                .FirstOrDefaultAsync(p => p.PulishingHouse == PublishingHouse);
        }
    }
}
