using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using BookStore.Utils.Global;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task<BaseCommandResultWithData<User>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<User>();
            try
            {
                var user = userManager.FindByNameAsync(request.UserNameOrEmail).Result;
                // Tìm UserName theo Email, đăng nhập lại
                if(user == null && new EmailAddressAttribute().IsValid(request.UserNameOrEmail))
                {
                    user = userManager.FindByEmailAsync(request.UserNameOrEmail).Result;
                    if (user != null)
                    {
                        var check = await signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, lockoutOnFailure: true);
                        if (check.Succeeded)
                        {
                            AppGlobal.RequiresTwoFactor = check.RequiresTwoFactor;
                            AppGlobal.IsLockedOut = check.IsLockedOut;
                            result.Data = user;
                            result.Success = true;
                        }
                        else
                        {
                            result.Message = AppGlobal.InvalidUserName;
                        }
                    }
                }
                else
                {
                    if (user != null)
                    {
                        var check = await signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, lockoutOnFailure: true);
                        if (check.Succeeded)
                        {
                            result.Data = user;
                            result.Success = true;
                        }
                        else
                        {
                            result.Message = AppGlobal.InvalidUserName;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                result.Message = e.Message;
            }
            return result;
        }
    }
}
