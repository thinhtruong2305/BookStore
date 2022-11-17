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
    public class RecoveryCategoryHandler : IRequestHandler<RecoveryCategoryRequest, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public RecoveryCategoryHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public Task<BaseCommandResult> Handle(RecoveryCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var category = database.Categories
                    .Where(b => b.Status == Status.Delete)
                    .FirstOrDefault(b => b.CategoryId == request.Id);


                if (category != null)
                {
                    Status status = Status.InActive;

                    category.Status = status;
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
