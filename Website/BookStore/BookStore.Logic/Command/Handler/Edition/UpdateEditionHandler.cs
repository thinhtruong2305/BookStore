using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class UpdateEditionHandler : IRequestHandler<UpdateEditionRequest, BaseCommandResultWithData<Edition>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateEditionHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Edition>> Handle(UpdateEditionRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Edition>();

            try
            {
                var edition = database.Editions
                    .Where(e => e.Status != Status.Delete)
                    .AsNoTracking()
                    .FirstOrDefault(e => e.EditionId == request.EditionId);

                if(edition != null)
                {
                    var editionSave = mapper.Map(request, edition);
                    editionSave.SetUpdateInfo(request.UserName ?? string.Empty, AppGlobal.SysDateTime);
                    
                    result.Success = true;
                    result.Data = database.Editions.Update(editionSave);
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
