using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public DeleteCategoryHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResult> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var category = database.Categories
                    .FirstOrDefault(b => b.CategoryId == request.Id);

                if (category != null)
                {
                    category.MarkAsDelete(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    database.Update(category);
                    database.SaveChanges();

                    result.Success = true;
                }
                else
                {
                    result.Message = "Không thể thực hiện. Vui lòng kiểm tra lại id!";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return Task.FromResult(result);
        }
    }
}