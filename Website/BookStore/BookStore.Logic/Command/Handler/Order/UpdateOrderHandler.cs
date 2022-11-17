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
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderRequest, BaseCommandResultWithData<Order>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateOrderHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Order>> Handle(UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Order>();

            try
            {
                var order = database.Orders
                    .Where(o => o.Status != Status.Delete)
                    .FirstOrDefault(o => o.OrderId == request.OrderId);

                if(order != null)
                {
                    mapper.Map(request, order);
                    order.SetUpdateInfo(request.UserName ?? String.Empty, DateTime.Now);
                    database.Orders.Update(order);
                    database.SaveChanges();

                    result.Success = true;
                    result.Data = order;
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
