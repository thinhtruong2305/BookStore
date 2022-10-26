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
    public class CreateRatingHandler : IRequestHandler<CreateRatingRequest, BaseCommandResultWithData<Rating>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateRatingHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Rating>> Handle(CreateRatingRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Rating>();

            try
            {
                var rating = mapper.Map<Rating>(request);
                rating.SetCreateInfo(request.UserName ?? String.Empty, DateTime.Now);
                database.Ratings.Add(rating);
                database.SaveChanges();

                result.Success = true;
                result.Data = rating;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
