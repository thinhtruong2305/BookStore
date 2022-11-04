using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using MediatR;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class UpdateMenuHandler : IRequestHandler<UpdateMenuRequest, BaseCommandResultWithData<Menu>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateMenuHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Menu>> Handle(UpdateMenuRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Menu>();

            try
            {
                var menu = database.Menus
                    .Where(m => m.Status != Status.Delete)
                    .FirstOrDefault(m => m.MenuId == request.MenuId);

                if(menu != null)
                {
                    mapper.Map(request, menu);
                    menu.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                    database.Menus.Update(menu);

                    result.Success = true;
                    result.Data = menu;
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
