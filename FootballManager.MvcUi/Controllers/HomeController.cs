using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FootballManager.MvcUi.Models;
using FootballManager.MvcUi.Services;
using FootBallManager.Entities.Concrete;
using FootballManager.Bll.Helpers;
using FootballManager.Bll.Concrete;

namespace FootballManager.MvcUi.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUserSessionService userSessionService, IUserCookieService userCookieService)
            : base(userSessionService, userCookieService)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //ViewBag.IsLogin = IsLogin;
            //if (IsLogin)
            //{
            //    EntityHttpResponse entityHttpResponse = await ApiCenter.GetAsync($"User");
            //    if (entityHttpResponse.IsTrue)
            //    {
            //        return View();

            //    }
            //    else
            //    {
            //        TempData.Add("RegisterErrorMasage", entityHttpResponse._Data);
            //        return View(TempData);
            //    }

            //}
            return View();

        }

        [HttpPut]
        public async Task<IActionResult> PlayMatch()
        {


            EntityHttpResponse entityResponse = await ApiCenter.GetAsync($"Season/CreateSeason");


            return View();

        }


        [HttpGet]
        public async Task<IActionResult> UserDetail()
        {
            ViewBag.IsLogin = IsLogin;
            if (IsLogin)
            {
                User user = LoginUser();

                EntityHttpResponse entityHttpResponseTeam = await ApiCenter.GetAsync($"Team/{user.Teamid}");
                if (entityHttpResponseTeam.IsTrue)
                {
                    Team team = ApiCenter.getData<Team>(entityHttpResponseTeam);
                    EntityHttpResponse entityHttpResponseStadium = await ApiCenter.GetAsync($"Stadium/{team.Stadiumid}");
                    if (entityHttpResponseStadium.IsTrue)
                    {
                        Stadium stadium = ApiCenter.getData<Stadium>(entityHttpResponseStadium);
                        ViewBag.LoadError = false;
                        TempData.Clear();
                        return View(new AccountListViewModel(user, team, stadium));
                    }
                }
                ViewBag.LoadError = true;
                TempData.Add("UserDetailErrorMesage","Kullaniciya ait bilgiler tamamen yuklenemedi");
                return View(null);
            }

            else
            {

                return RedirectToAction("Login", "Account");
            }


        }

    }



}
