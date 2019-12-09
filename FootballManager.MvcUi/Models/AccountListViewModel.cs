using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FootballManager.MvcUi.Controllers.HomeController;

namespace FootballManager.MvcUi.Models
{
    public class AccountListViewModel 
    {
        public AccountListViewModel(User user, Team team, Stadium stadium)
        {
            User = user;
            Team = team;
            Stadium = stadium;
        }
        public User User{ get; set; }
        public Team Team { get; set; }
        public Stadium Stadium { get; set; }

    }
}
