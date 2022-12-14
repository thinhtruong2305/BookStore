using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using MediatR;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class CreateEditionHandler : IRequestHandler<CreateEditionRequest, BaseCommandResultWithData<Edition>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreateEditionHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Edition>> Handle(CreateEditionRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Edition>();

            try
            {
                var edition = mapper.Map<Edition>(request);
                request.SetCreateInfo(request.UserName ?? string.Empty, DateTime.Now);

                result.Success = true;
                result.Data = database.Editions.Add(edition); ;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
