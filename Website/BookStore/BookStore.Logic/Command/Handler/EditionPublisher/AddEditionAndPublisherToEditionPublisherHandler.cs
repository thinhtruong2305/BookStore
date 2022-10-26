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
    public class AddEditionAndPublisherToEditionPublisherHandler : IRequestHandler<AddEditionAndPublisherToEditionPubliserRequest, BaseCommandResultWithData<EditionPublisher>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public AddEditionAndPublisherToEditionPublisherHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<EditionPublisher>> Handle(AddEditionAndPublisherToEditionPubliserRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<EditionPublisher>();

            try
            {
                var editionPublisher = mapper.Map<EditionPublisher>(request);
                database.EditionPublishers.Add(editionPublisher);
                database.SaveChanges();

                result.Success = true;
                result.Data = editionPublisher;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
