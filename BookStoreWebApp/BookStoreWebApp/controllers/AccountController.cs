using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Model;
using BookStoreWebApp.Repository;
using Microsoft.AspNetCore.Routing;

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
                ModelState.AddModelError("","Invalid Credentials");
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


    }
}
