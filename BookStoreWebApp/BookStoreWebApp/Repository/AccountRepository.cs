﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Model;
using Microsoft.AspNetCore.Identity;

namespace BookStoreWebApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public readonly UserManager<IdentityUser> _userManager;
        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;

        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new IdentityUser()
            {
                Email = userModel.Email,
                UserName = userModel.Email
            };
           var result =  await _userManager.CreateAsync(user, userModel.Password);
           return result;
        }
    }
}
