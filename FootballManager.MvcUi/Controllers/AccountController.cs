using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballManager.Bll.Concrete;
using FootballManager.Bll.Helpers;
using FootballManager.MvcUi.Models;
using FootballManager.MvcUi.Services;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using static FootballManager.Bll.Helpers.ToPasswordRepository;


namespace FootballManager.MvcUi.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IUserSessionService userSessionService, IUserCookieService userCookieService) 
            : base(userSessionService, userCookieService)
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            loginViewModel.Password = PasswordCryptographyCombine(loginViewModel.Password);
            EntityHttpResponse entityHttpResponse = await ApiCenter.GetAsync($"User/Login/{loginViewModel.Email}/{loginViewModel.Password}");
            if (entityHttpResponse.IsTrue)
            {
                User user = ApiCenter.getData<User>(entityHttpResponse);
                LoginUserSave(user);
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData.Add("LoginErrorMasage", entityHttpResponse._Data);
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (registerViewModel.Password.Equals(registerViewModel.PasswordConfirmation))
            {
                
                registerViewModel.Password = PasswordCryptographyCombine(registerViewModel.Password);
                EntityHttpResponse entityHttpResponse = await ApiCenter.GetAsync($"User/Register/{registerViewModel.Email}/{registerViewModel.Password}/{registerViewModel.UserName}");
                if (entityHttpResponse.IsTrue)
                    return RedirectToAction("Login",1);
                else
                {
                    TempData.Add("RegisterErrorMasage", entityHttpResponse._Data);
                    return View();
                }
            }
            else
            {
                TempData.Add("RegisterErrorMasage", "adgangskoder stemmer ikke overens");
                return View();
            }
        }
    }
}