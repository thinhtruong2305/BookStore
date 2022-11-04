using BookStore.Logic.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Interface
{
    public interface IPublisherQueries
    {
        public List<PublisherSummaryModel> GetAll();
        public Task<List<PublisherSummaryModel>> GetAllAsync();
        public List<PublisherSummaryModel> GetAllDelete();
        public Task<List<PublisherSummaryModel>> GetAllDeleteAsync();
        public PublisherDetailModel? GetDetail(int PublisherId);
        public Task<PublisherDetailModel?> GetDetailAsync(int PublisherId);
    }
}
