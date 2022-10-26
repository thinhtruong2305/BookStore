using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class UpdateSeriesHandler : IRequestHandler<UpdateSeriesRequest, BaseCommandResultWithData<Series>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateSeriesHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Series>> Handle(UpdateSeriesRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Series>();

            try
            {
                var series = database.Series
                    .Where(s => s.Status != Status.Delete)
                    .FirstOrDefault(s => s.SeriesId == request.SeriesId);

                if (series != null)
                {
                    mapper.Map(request, series);
                    series.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                    database.Series.Update(series);
                    database.SaveChanges();

                    result.Success = true;
                    result.Data = series;
                }
                else
                {
                    result.Message = "Không thể thực hiện. Vui lòng kiểm tra lại id!";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
