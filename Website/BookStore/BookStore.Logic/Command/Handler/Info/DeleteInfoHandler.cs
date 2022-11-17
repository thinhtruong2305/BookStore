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
    public class DeleteInfoHandler : IRequestHandler<DeleteInfoRequest, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public DeleteInfoHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResult> Handle(DeleteInfoRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var info = database.Infos
                    .FirstOrDefault(info => info.InfoId == request.Id);

                if (info != null)
                {
                    info.MarkAsDelete(request.UserName ?? String.Empty, DateTime.Now);
                    database.Infos.Update(info);
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
