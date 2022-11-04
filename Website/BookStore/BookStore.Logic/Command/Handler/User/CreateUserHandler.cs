using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, BaseCommandResultWithData<User>>
    {
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly AppDatabase database;

        public CreateUserHandler(UserManager<User> userManager, 
            IMapper mapper, 
            AppDatabase database)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.database = database;
        }
        public Task<BaseCommandResultWithData<User>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<User>();

            try
            {
                var user = mapper.Map<User>(request);
                var createResult = userManager.CreateAsync(user, request.Password);

                if (createResult.Result.Succeeded)
                {
                    result.Data = user;
                    result.Success = true;
                }
                else
                {
                    result.Message = string.Join("-", createResult.Result.Errors.Select(x => x.Description));
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
