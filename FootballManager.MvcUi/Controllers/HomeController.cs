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

namespace FootballManager.MvcUi.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUserSessionService userSessionService) : base(userSessionService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
