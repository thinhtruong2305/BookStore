using BookStore.Common.Shared.Model;
using BookStore.DAL.Entities;
using BookStore.Logic.Shared.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Request
{
    public class ChangeAuthorStatusRequest : IIdentifiedCommand,
        IRequest<BaseCommandResult>
    {
        public int Id { get; set; }
        public string? RequestId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? IpAddress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? UserName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
