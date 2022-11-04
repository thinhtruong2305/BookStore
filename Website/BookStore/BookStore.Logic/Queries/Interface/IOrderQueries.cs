using BookStore.Logic.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Interface
{
    public interface IOrderQueries
    {
        public List<OrderSummaryModel> GetAll();
        public Task<List<OrderSummaryModel>> GetAllAsync();
        public List<OrderSummaryModel> GetAllDelete();
        public Task<List<OrderSummaryModel>> GetAllDeleteAsync();
        public OrderDetailModel? GetDetail(int OrderId);
        public Task<OrderDetailModel?> GetDetailAsync(int OrderId);
    }
}
