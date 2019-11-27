using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManager.MvcUi.Services
{
    public interface IUserSessionService
    {
        User Get(string key);
        void Set(User value,string key);
    }
}
