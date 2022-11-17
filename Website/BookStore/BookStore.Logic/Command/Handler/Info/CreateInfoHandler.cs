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
    public class CreateInfoHandler : IRequestHandler<CreateInfoRequest, BaseCommandResultWithData<Info>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateInfoHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Info>> Handle(CreateInfoRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Info>();

            try
            {
                var info = mapper.Map<Info>(request);
                info.SetCreateInfo(request.UserName ?? String.Empty, DateTime.Now);

                result.Success = true;
                result.Data = database.Infos.Add(info);
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
