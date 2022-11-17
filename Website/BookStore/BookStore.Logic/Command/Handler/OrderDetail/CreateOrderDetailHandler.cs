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
    public class CreateOrderDetailHandler : IRequestHandler<CreateOrderDetailRequest, BaseCommandResultWithData<OrderDetail>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateOrderDetailHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<OrderDetail>> Handle(CreateOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<OrderDetail>();

            try
            {
                var orderDetail = mapper.Map<OrderDetail>(request);
                orderDetail.SetCreateInfo(request.UserName ?? String.Empty, DateTime.Now);

                result.Success = true;
                result.Data = database.OrderDetails.Add(orderDetail);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
