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
            ViewBag.IsLogin = IsLogin;
            if (IsLogin)
            {
                EntityHttpResponse entityHttpResponse = await ApiCenter.GetAsync($"User");
                if (entityHttpResponse.IsTrue)
                {
                    return View();

                }
                else
                {
                    TempData.Add("RegisterErrorMasage", entityHttpResponse._Data);
                    return View(TempData);
                }

            }
            return View();

        }

        [HttpPut]
        public async Task<IActionResult> PlayMatch()
        {
           

            EntityHttpResponse entityResponse = await ApiCenter.GetAsync($"Season/CreateSeason");


            return View();

        }


        [HttpGet]
        public async Task<IActionResult> UserDetail(int id)
        {
            ViewBag.IsLogin = IsLogin;
            if (IsLogin)
            {
                EntityHttpResponse entityHttpResponseUSer = await ApiCenter.GetAsync($"User/Detail/{id}");
                EntityHttpResponse entityHttpResponseTeams = await ApiCenter.GetAsync($"Team");
              
                if (entityHttpResponseUSer.IsTrue)
                {
                    User user = ApiCenter.getData<User>(entityHttpResponseUSer);

                    EntityHttpResponse entityHttpResponseTeam = await ApiCenter.GetAsync($"Team/Detail/{user.id}");
                    if (entityHttpResponseTeam.IsTrue)
                    {
                        Team team = ApiCenter.getData<Team>(entityHttpResponseTeam);

                        List<Team> teams;
                        teams = ApiCenter.getData<List<Team>>(entityHttpResponseTeams);
                        EntityHttpResponse entityHttpResponseStadium = await ApiCenter.GetAsync($"Stadium/{team.Stadiumid}");
                        Stadium stadium = ApiCenter.getData<Stadium>(entityHttpResponseStadium);


                        return View(new AccountListViewModel(user, team, teams, stadium));
                    }
                    TempData.Add("RegisterErrorMasage", entityHttpResponseUSer._Data);
                    return View();
                }
                else
                {
                    TempData.Add("RegisterErrorMasage", entityHttpResponseUSer._Data);
                    return View();
                }


            }

            else
            {

                return RedirectToAction("Login", "Account");
            }
            

        }
           
    }



}
