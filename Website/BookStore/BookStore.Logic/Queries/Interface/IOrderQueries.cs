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
        public OrderDetailModel GetDetail(int OrderId);
        public Task<OrderDetailModel> GetDetailAsync(int OrderId);
    }
}
