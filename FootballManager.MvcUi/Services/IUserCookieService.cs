using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManager.MvcUi.Services
{
    public interface IUserCookieService
    {
        void Set(string key, object value, int? expireTime);
        User Get(string key);
        void Remove(string key);
    }
}
