using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using MediatR;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, BaseCommandResultWithData<Order>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateOrderHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Order>> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Order>();

            try
            {
                var order = mapper.Map<Order>(request);
                order.SetCreateInfo(request.UserName ?? String.Empty, DateTime.Now);

                result.Success = true;
                result.Data = database.Orders.Add(order);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
