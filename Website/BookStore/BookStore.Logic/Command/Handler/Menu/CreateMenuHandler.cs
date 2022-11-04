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
    public class CreateMenuHandler : IRequestHandler<CreateMenuRequest, BaseCommandResultWithData<Menu>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateMenuHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Menu>> Handle(CreateMenuRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Menu>();

            try
            {
                var menu = mapper.Map<Menu>(request);
                menu.SetCreateInfo(request.UserName ?? string.Empty, DateTime.Now);
                database.Menus.Add(menu);

                result.Success = true;
                result.Data = menu;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
