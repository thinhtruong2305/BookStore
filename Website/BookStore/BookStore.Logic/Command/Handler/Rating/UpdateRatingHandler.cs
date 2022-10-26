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
    public class UpdateRatingHandler : IRequestHandler<UpdateRatingRequest, BaseCommandResultWithData<Rating>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateRatingHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Rating>> Handle(UpdateRatingRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Rating>();

            try
            {
                var rating = database.Ratings
                    .Where(r => r.Status != Status.Delete)
                    .FirstOrDefault(r => r.RatingId == request.RatingId);

                if (rating != null)
                {
                    mapper.Map(request, rating);
                    rating.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                    database.Ratings.Update(rating);
                    database.SaveChanges();

                    result.Success = true;
                    result.Data = rating;
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
