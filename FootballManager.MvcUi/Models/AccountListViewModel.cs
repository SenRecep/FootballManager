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
        public AccountListViewModel(User user, Team team, Stadium stadium, List<Team> Commingteams)
        {
            User = user;
            Team = team;
            Stadium = stadium;
            teams = Commingteams;
        }
        public User User{ get; set; }
        public Team Team { get; set; }
        public Stadium Stadium { get; set; }
        public  List<Team> teams { get; set; }

    }
}
