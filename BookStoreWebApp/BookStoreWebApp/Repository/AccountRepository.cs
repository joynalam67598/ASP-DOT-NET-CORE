using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Model;
using BookStoreWebApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BookStoreWebApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AccountRepository(UserManager<ApplicationUserModel> userManager, 
            SignInManager<ApplicationUserModel> signInManager,
            IUserService userService, IEmailService emailService, IConfiguration configuration )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _emailService = emailService;
            _configuration = configuration;
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
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                if(!string.IsNullOrEmpty(token))
                {
                    await SendConfirmationEmail(user, token);
                }
            }
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

        public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
        {
           return await _userManager.ConfirmEmailAsync(await _userManager.FindByIdAsync(uid),token);

        }

        private async Task SendConfirmationEmail(ApplicationUserModel user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string configurationLink = _configuration.GetSection("Application:EmailConfirmation").Value;


            UserEmailOptions emailOptions = new UserEmailOptions
            {
                ToEmails = new List<string>() { user.Email }, //fake smtp credentials
                PlaceHolders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}",user.FirstName),
                     new KeyValuePair<string, string>("{{link}}", string.Format(appDomain + configurationLink, user.Id, token)),
                }
            };
            await _emailService.SendEamilForConfirmationEmail(emailOptions);


        }
    }
}
