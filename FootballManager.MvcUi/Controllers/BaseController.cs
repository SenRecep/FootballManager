using FootballManager.MvcUi.Services;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FootballManager.MvcUi
{
    public class BaseController : Controller
    {
        public User LoginUser => userSessionService.Get("LoginUser");
        public void LoginUserSave(User user) => userSessionService.Set(user, "LoginUser");
        public void ClearUser() => userSessionService.Set(null, "LoginUser");
        public bool IsLogin => LoginUser != null;

        private readonly IUserSessionService userSessionService;

        public BaseController(IUserSessionService userSessionService)
        {
            this.userSessionService = userSessionService;
        }
        public BaseController()
        {
        }
    }
}