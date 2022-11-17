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
    public class CreateSeriesHandler : IRequestHandler<CreateSeriesRequest, BaseCommandResultWithData<Series>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateSeriesHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Series>> Handle(CreateSeriesRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Series>();

            try
            {
                var series = mapper.Map<Series>(request);
                series.SetCreateInfo(request.UserName ?? String.Empty, DateTime.Now);

                result.Success = true;
                result.Data = database.Series.Add(series);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
