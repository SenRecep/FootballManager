﻿using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballManager.MvcUi.ExtensionMethods;

namespace FootballManager.MvcUi.Services
{
    public class UserSessionService : IUserSessionService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserSessionService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }


        public User Get(string key)
        {
            return httpContextAccessor.HttpContext.Session.GetObj<User>(key);
        }

        public void Set(User value, string key)
        {
            httpContextAccessor.HttpContext.Session.SetObj(key,value);
        }
    }
}
