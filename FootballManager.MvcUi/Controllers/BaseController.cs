using FootballManager.MvcUi.Services;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FootballManager.MvcUi
{
    public class BaseController : Controller
    {
        public bool LoadLoginUser { get; set; }
        public User LoginUser()
        {
            LoadUser();
            return userSessionService.Get("LoginUser");
        }
        public void LoginUserSave(User user)
        {
            userCookieService.Set("LoginUser",user,60*24*10);//10 gun
            LoadLoginUser = false;
            LoadUser();
        }
        public void ClearUser()
        {
            userSessionService.Set(null, "LoginUser");
            userCookieService.Remove("LoginUser");
        }
        public bool IsLogin => LoginUser() != null;

        private readonly IUserSessionService userSessionService;
        private readonly IUserCookieService userCookieService;

        public BaseController(IUserSessionService userSessionService, IUserCookieService userCookieService)
        {
            this.userSessionService = userSessionService;
            this.userCookieService = userCookieService;
        }
        public BaseController()
        {
        }

        private void LoadUser()
        {
            User user = null;
            if (LoadLoginUser)
                user = userCookieService.Get("LoginUser");
            LoadLoginUser = user != null;
            if (LoadLoginUser)
                LoginUserSave(user);
        }
    }
}