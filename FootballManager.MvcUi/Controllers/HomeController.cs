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

        public HomeController(IUserSessionService userSessionService) : base(userSessionService)
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
                    return View();
                }

            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> User(int id)
        {
            ViewBag.IsLogin = IsLogin;
            if (IsLogin)
            {
                EntityHttpResponse entityHttpResponse = await ApiCenter.GetAsync($"User/Detail/{id}");
                if (entityHttpResponse.IsTrue)
                {
                    User user = ApiCenter.getData<User>(entityHttpResponse);

                    EntityHttpResponse entityHttpResponseTeam = await ApiCenter.GetAsync($"Team/Detail/{user.id}");
                    if (entityHttpResponseTeam.IsTrue)
                    {
                        Team team = ApiCenter.getData<Team>(entityHttpResponseTeam);

                        return View(new AccountListViewModel(user, team));
                    }
                    else
                    {
                        TempData.Add("RegisterErrorMasage", entityHttpResponse._Data);
                        return View();
                    }


                }

                else
                {
                    TempData.Add("RegisterErrorMasage", entityHttpResponse._Data);
                    return View();
                }


            }
            return View();
        }


    }
}
