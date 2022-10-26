﻿using AutoMapper;
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
    public class SeriesQueries : ISeriesQueries
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public SeriesQueries(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public List<SeriesSummaryModel> GetAll()
        {
            return database.Series
                .Where(s => s.Status != Common.Shared.Model.Status.Delete)
                .Include(s => s.info)
                    .ThenInclude(info => info.Book)
                        .ThenInclude(b => b.AuthorBooks)
                .Select(s => mapper.Map<SeriesSummaryModel>(s))
                .ToList();
        }

        public Task<List<SeriesSummaryModel>> GetAllAsync()
        {
            return database.Series
                .Where(s => s.Status != Common.Shared.Model.Status.Delete)
                .Include(s => s.info)
                    .ThenInclude(info => info.Book)
                        .ThenInclude(b => b.AuthorBooks)
                .Select(s => mapper.Map<SeriesSummaryModel>(s))
                .ToListAsync();
        }

        public SeriesDetailModel GetDetail(int SeriesId)
        {
            return database.Series
                .Where(s => (s.Status != Common.Shared.Model.Status.Delete) && (s.SeriesId == SeriesId))
                .Include(s => s.info)
                    .ThenInclude(info => info.Book)
                        .ThenInclude(b => b.AuthorBooks)
                .Select(s => mapper.Map<SeriesDetailModel>(s))
                .First();
        }

        public Task<SeriesDetailModel> GetDetailAsync(int SeriesId)
        {
            return database.Series
                .Where(s => (s.Status != Common.Shared.Model.Status.Delete) && (s.SeriesId == SeriesId))
                .Include(s => s.info)
                    .ThenInclude(info => info.Book)
                        .ThenInclude(b => b.AuthorBooks)
                .Select(s => mapper.Map<SeriesDetailModel>(s))
                .FirstAsync();
        }
    }
}
 