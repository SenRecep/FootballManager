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
        public AccountListViewModel(User user, Team team, List<Team> teams, Stadium stadium)
        {
            User = user;
            Team = team;
            AllTeams = teams;
            Stadium = stadium;
        }
        public User User{ get; set; }
        public Team Team { get; set; }
        public Stadium Stadium { get; set; }
        public List<Player> Players { get; set; }
        public List<Team> AllTeams { get; set; }

    }
}
