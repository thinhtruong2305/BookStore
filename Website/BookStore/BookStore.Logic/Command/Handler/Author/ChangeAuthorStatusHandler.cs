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
    public class ChangeAuthorStatusHandler : IRequestHandler<ChangeAuthorStatusRequest, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public ChangeAuthorStatusHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResult> Handle(ChangeAuthorStatusRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var author = database.Authors
                    .Where(a => a.Status != Status.Delete)
                    .FirstOrDefault(a => a.AuthorId == request.Id);

                if (author != null)
                {
                    Status status = (author.Status == Status.Active) ? Status.InActive : Status.Active;
                    author.Status = status;
                    author.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                    database.Entry(author).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
