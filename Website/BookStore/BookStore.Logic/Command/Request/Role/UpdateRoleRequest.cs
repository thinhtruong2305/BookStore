using BookStore.Common.Shared.Model;
using BookStore.Logic.Shared.Interface;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Request
{
    public class UpdateRoleRequest : IdentityRole,
        IIdentifiedCommand,
        IRequest<BaseCommandResultWithData<IdentityRole>>
    {
        public string? Password { get; set; }
        public string? RequestId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserName { get; set; }
    }
}
