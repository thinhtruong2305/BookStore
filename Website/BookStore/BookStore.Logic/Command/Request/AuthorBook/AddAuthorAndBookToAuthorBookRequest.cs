﻿using BookStore.Common.Shared.Model;
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
    public class AddAuthorAndBookToAuthorBookRequest : AuthorBook,
        IIdentifiedCommand,
        IRequest<BaseCommandResultWithData<AuthorBook>>
    {
        public string? RequestId { get; set; }
        public string? IpAddress { get; set; }
        public string? UserName { get; set; }
    }
}
