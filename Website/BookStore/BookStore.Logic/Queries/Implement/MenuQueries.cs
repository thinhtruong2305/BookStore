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
    public class MenuQueries : IMenuQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public MenuQueries(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public List<MenuSummaryModel> GetAll()
        {
            return database.Menus
                .Where(m => m.Status != Common.Shared.Model.Status.Delete)
                .Select(m => mapper.Map<MenuSummaryModel>(m))
                .ToList();
        }

        public Task<List<MenuSummaryModel>> GetAllAsync()
        {
            return database.Menus
                .Where(m => m.Status != Common.Shared.Model.Status.Delete)
                .Select(m => mapper.Map<MenuSummaryModel>(m))
                .ToListAsync();
        }

        public MenuDetailModel GetDetail(int MenuId)
        {
            return database.Menus
                .Where(m => (m.Status != Common.Shared.Model.Status.Delete) && (m.MenuId == MenuId))
                .Include(m => m.Tags)
                .Select(m => mapper.Map<MenuDetailModel>(m))
                .First();
        }

        public Task<MenuDetailModel> GetDetailAsync(int MenuId)
        {
            return database.Menus
                .Where(m => (m.Status != Common.Shared.Model.Status.Delete) && (m.MenuId == MenuId))
                .Include(m => m.Tags)
                .Select(m => mapper.Map<MenuDetailModel>(m))
                .FirstAsync();
        }
    }
}
