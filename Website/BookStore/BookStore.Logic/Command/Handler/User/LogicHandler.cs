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
    public class LogicHandler : IRequestHandler<LoginRequest, BaseCommandResultWithData<User>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public LogicHandler(AppDatabase database
            ,IMapper mapper
            ,UserManager<User> userManager
            ,SignInManager<User> signInManager)
        {
            this.database = database;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public Task<BaseCommandResultWithData<User>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<User>();
            try
            {
                var user = userManager.FindByNameAsync(request.UserName).Result;
                if (user != null)
                {
                    var isPasswordValid = userManager.CheckPasswordAsync(user, request.Password).Result;
                    if (isPasswordValid)
                    {
                        result.Success = true;
                        result.Data = user;
                    }
                    else
                    {
                        result.Message = AppGlobal.InvalidPassword;
                    }
                }
                else
                {
                    result.Message = AppGlobal.InvalidUserName;
                }
            }
            catch(Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
