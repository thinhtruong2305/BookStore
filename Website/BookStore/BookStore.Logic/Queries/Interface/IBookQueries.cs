using BookStore.Logic.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Queries.Interface
{
    /// <summary>
    /// Phần này dùng để hiển thị
    /// </summary>
    public interface IBookQueries
    {
        public List<BookSummaryClientModel> GetAllClient();
        public Task<List<BookSummaryClientModel>> GetAllClientAsync();
    }
}
