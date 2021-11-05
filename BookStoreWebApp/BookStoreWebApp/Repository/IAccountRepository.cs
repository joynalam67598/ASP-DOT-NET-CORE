﻿using System.Threading.Tasks;
using BookStoreWebApp.Model;
using Microsoft.AspNetCore.Identity;

namespace BookStoreWebApp.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePasswordModel);

        Task<IdentityResult> ConfirmEmailAsync(string uid, string token);
    }
}