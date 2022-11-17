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
    internal class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, BaseCommandResultWithData<Category>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateCategoryHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Category>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Category>();

            try
            {
                var category = database.Categories
                    .Where(a => a.Status != Status.Delete)
                    .FirstOrDefault(a => a.CategoryId == request.CategoryId);

                if (category != null)
                {
                    var categorySave = mapper.Map(request, category);
                    categorySave.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);

                    result.Success = true;
                    result.Data = database.Update(categorySave);
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