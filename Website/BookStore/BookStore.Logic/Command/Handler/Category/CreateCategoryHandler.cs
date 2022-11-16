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
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, BaseCommandResultWithData<Category>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateCategoryHandler(AppDatabase database,
            IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Category>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Category>();

            try
            {
                var category = mapper.Map<Category>(request);
                category.SetCreateInfo(request.UserName ?? string.Empty, DateTime.Now);

                result.Data = database.Categories.Add(category);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
