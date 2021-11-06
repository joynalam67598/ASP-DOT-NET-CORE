using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Model;
using BookStoreWebApp.Repository;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreWebApp.Controllers
{
    public class AccountController : Controller
    {
        public readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        [Route("signUp")]
        public IActionResult SignUp()
        {
            return View();
        }
        [Route("signUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                }
                else ModelState.Clear();
                return RedirectToAction("ConfirmEmail", new { email = userModel.Email });
            }
            return View();

        }

        [Route("signIn")]

        public IActionResult SignIn()
        {
            return View();
        }
        [Route("signIn")]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel signInModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Not allowed to login");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            return View(signInModel);
        }
        
        [Route("signOut")]
        public async Task<IActionResult> SignOut()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Route("change-password")]
        public IActionResult ChangePassword() => View();

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string uid, string token, string email)
        {
            EmailConfirmationModel emailConfirmationModel = new EmailConfirmationModel
            {
                Email = email,
            };
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
                var result = await _accountRepository.ConfirmEmailAsync(uid, token);
                if (result.Succeeded)
                {
                    emailConfirmationModel.EmailVerified = true;
                }
            }
            return View(emailConfirmationModel);
        }

        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(EmailConfirmationModel emailConfirmationModel)
        {
            var user = await _accountRepository.GetuserByEmailAsync(emailConfirmationModel.Email);
            if (user != null)
            {
                if (user.EmailConfirmed)
                {
                    emailConfirmationModel.IsConfirmed = true;
                    return View(emailConfirmationModel);
                }

                await _accountRepository.GenerateEmailConfirmationTokenAsync(user);
                emailConfirmationModel.EmailSent = true;
                ModelState.Clear();

            }
            else
            {
                ModelState.AddModelError("", "Opps! Something went wrong.");
            }
            return View(emailConfirmationModel);
        }

        [AllowAnonymous, HttpGet("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous, HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            var user = await _accountRepository.GetuserByEmailAsync(forgotPasswordModel.Email);
            if (user != null)
            {
                await _accountRepository.GenerateForgotPasswordTokenAsync(user);
            }
            ModelState.Clear();
            forgotPasswordModel.EmailSent = true;

            return View(forgotPasswordModel);
        }

        [AllowAnonymous, HttpGet("reset-password")]
        public IActionResult ResetPassword(string uid, string token)
        {
            ResetPasswordModel model = new ResetPasswordModel
            {
                UserId = uid,
                Token = token,
            };
            return View(model);
        }

        [AllowAnonymous, HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            if(ModelState.IsValid)
            {
                resetPasswordModel.Token = resetPasswordModel.Token.Replace(' ', '+');

                var result = await _accountRepository.ResetPasswordAsync(resetPasswordModel);
                if(result.Succeeded)
                {

                    ModelState.Clear();
                    resetPasswordModel.IsSuccess = true;
                    return View(resetPasswordModel);

                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(resetPasswordModel);
        }



    }
}
