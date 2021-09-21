using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Model;
using Microsoft.AspNetCore.Identity;

namespace BookStoreWebApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public readonly UserManager<ApplicationUserModel> _userManager;
        public AccountRepository(UserManager<ApplicationUserModel> userManager)
        {
            _userManager = userManager;

        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUserModel()
            {
                Email = userModel.Email,
                UserName = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
            };
           var result =  await _userManager.CreateAsync(user, userModel.Password);
           return result;
        }
    }
}
