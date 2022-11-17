using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL.Entities;
using BookStore.DAL;
using BookStore.Logic.Command.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class CreatePublisherHandler : IRequestHandler<CreatePublisherRequest, BaseCommandResultWithData<Publisher>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public CreatePublisherHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<Publisher>> Handle(CreatePublisherRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<Publisher>();

            try
            {
                var publisher = mapper.Map<Publisher>(request);
                publisher.SetCreateInfo(request.UserName ?? String.Empty, DateTime.Now);

                result.Success = true;
                result.Data = database.Publishers.Add(publisher); ;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
