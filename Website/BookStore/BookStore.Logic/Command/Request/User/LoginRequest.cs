using BookStore.Common.Shared.Model;
using BookStore.DAL.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Request
{
    public class LoginRequest : IRequest<BaseCommandResultWithData<User>>
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool? RememberPassword { get; set; }
    }
}
