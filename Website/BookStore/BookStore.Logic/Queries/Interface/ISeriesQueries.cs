using BookStore.Logic.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Interface
{
    public interface ISeriesQueries
    {
        public List<SeriesSummaryModel> GetAll();
        public Task<List<SeriesSummaryModel>> GetAllAsync();
        public SeriesDetailModel GetDetail(int SeriesId);
        public Task<SeriesDetailModel> GetDetailAsync(int SeriesId);
    }
}
