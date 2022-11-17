using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
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
    public class UpdateInfoHandler : IRequestHandler<UpdateInfoRequest, BaseCommandResultWithData<Info>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public UpdateInfoHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Info>> Handle(UpdateInfoRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Info>();

            try
            {
                var info = database.Infos
                    .Where(info => info.Status != Status.Delete)
                    .AsNoTracking()
                    .FirstOrDefault(info => info.InfoId == request.InfoId);

                if(info != null)
                {
                    var infoSave = mapper.Map(request, info);
                    infoSave.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                    database.Infos.Update(infoSave);

                    result.Success = true;
                    result.Data = info;
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
