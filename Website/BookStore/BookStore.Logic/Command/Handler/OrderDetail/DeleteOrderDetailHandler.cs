using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.Logic.Command.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class DeleteOrderDetailHandler : IRequestHandler<DeleteOrderDetailRequest, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public DeleteOrderDetailHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResult> Handle(DeleteOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var orderDetail = database.OrderDetails
                    .FirstOrDefault(od => od.OrderDetailId == request.Id);

                if(orderDetail != null)
                {
                    orderDetail.MarkAsDelete(request.UserName ?? string.Empty, DateTime.Now);
                    database.OrderDetails.Update(orderDetail);
                    database.SaveChanges();

                    result.Success = true;
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
