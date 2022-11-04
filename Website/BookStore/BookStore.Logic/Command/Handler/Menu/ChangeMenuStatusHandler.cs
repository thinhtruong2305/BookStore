using BookStore.Common.Shared.Model;
using BookStore.Logic.Command.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class ChangeMenuStatusHandler : IRequestHandler<ChangeMenuStatusRequest, BaseCommandResult>
    {
        public Task<BaseCommandResult> Handle(ChangeMenuStatusRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
