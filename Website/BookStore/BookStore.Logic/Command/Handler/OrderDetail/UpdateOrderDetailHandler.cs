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
    public class UpdateOrderDetailHandler : IRequestHandler<UpdateOrderDetailRequest, BaseCommandResultWithData<OrderDetail>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateOrderDetailHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<OrderDetail>> Handle(UpdateOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<OrderDetail>();

            try
            {
                var orderDetail = database.OrderDetails
                    .Where(od => od.Status != Status.Delete)
                    .FirstOrDefault(od => od.OrderDetailId == request.OrderDetailId);

                if(orderDetail != null)
                {
                    orderDetail = mapper.Map<OrderDetail>(request);
                    orderDetail.SetUpdateInfo(request.UserName ?? String.Empty, DateTime.Now);
                    database.OrderDetails.Update(orderDetail);
                    database.SaveChanges();

                    result.Success = true;
                    result.Data = orderDetail;
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
