using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Model;
using BookStoreWebApp.Services;
using Microsoft.AspNetCore.Identity;

namespace BookStoreWebApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        private readonly IUserService _userService;

        public AccountRepository(UserManager<ApplicationUserModel> userManager, 
            SignInManager<ApplicationUserModel> signInManager,
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
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
        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            // perameter username, pass, cookie -> stay login or not , number of stamp to lock the account
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePasswordModel)
        {
            var userId = _userService.GetUserID();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user,changePasswordModel.CurrentPassword,changePasswordModel.NewPassword);

        }
    }
}
