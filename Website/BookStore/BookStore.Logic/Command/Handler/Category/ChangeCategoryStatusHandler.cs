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
    public class ChangeCategoryStatusHandler : IRequestHandler<ChangeCategoryStatusRequest, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public ChangeCategoryStatusHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResult> Handle(ChangeCategoryStatusRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var category = database.Categories
                    .Where(a => a.Status != Status.Delete)
                    .FirstOrDefault(a => a.CategoryId == request.Id);

                if (category != null)
                {
                    Status status = (category.Status == Status.Active) ? Status.InActive : Status.Active;
                    category.Status = status;
                    category.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                    database.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
