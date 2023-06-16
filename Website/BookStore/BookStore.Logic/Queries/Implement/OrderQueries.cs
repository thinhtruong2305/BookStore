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
    public class OrderQueries : IOrderQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public OrderQueries(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public List<OrderSummaryModel> GetAll()
        {
            return database.Orders
                .Where(o => o.Status != Common.Shared.Model.Status.Delete)
                .Select(o => mapper.Map<OrderSummaryModel>(o))
                .ToList();
        }

        public Task<List<OrderSummaryModel>> GetAllAsync()
        {
            return database.Orders
                .Where(o => o.Status != Common.Shared.Model.Status.Delete)
                .Select(o => mapper.Map<OrderSummaryModel>(o))
                .ToListAsync();
        }

        public List<OrderSummaryModel> GetAllDelete()
        {
            return database.Orders
                .Where(o => o.Status == Common.Shared.Model.Status.Delete)
                .Select(o => mapper.Map<OrderSummaryModel>(o))
                .ToList();
        }

        public Task<List<OrderSummaryModel>> GetAllDeleteAsync()
        {
            return database.Orders
                .Where(o => o.Status == Common.Shared.Model.Status.Delete)
                .Select(o => mapper.Map<OrderSummaryModel>(o))
                .ToListAsync();
        }

        public OrderDetailModel? GetDetail(Guid OrderId)
        {
            return database.Orders
                .Where(o => (o.Status != Common.Shared.Model.Status.Delete) && (o.OrderId == OrderId))
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                        .ThenInclude(b => b.Info)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                        .ThenInclude(b => b.Edition)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                        .ThenInclude(b => b.BookImages)
                .Select(o => mapper.Map<OrderDetailModel>(o))
                .FirstOrDefault();
        }

        public Task<OrderDetailModel?> GetDetailAsync(Guid OrderId)
        {
            return database.Orders
                .Where(o => (o.Status != Common.Shared.Model.Status.Delete) && (o.OrderId == OrderId))
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                        .ThenInclude(b => b.Info)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                        .ThenInclude(b => b.Edition)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Book)
                        .ThenInclude(b => b.BookImages)
                .Select(o => mapper.Map<OrderDetailModel>(o))
                .FirstOrDefaultAsync();
        }
    }
}
