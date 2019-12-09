using FootballManager.Bll.Abstract;
using FootballManager.Dal.Abstract;
using FootBallManager.Entities.ComplexTypes;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete.ObligatoryMethods
{
   public  class CreateMatches
    {
        private readonly TeamManager _teamManager;
        public CreateMatches(ITeamService teamService)
        {
            _teamManager = (TeamManager)teamService;
        }
        
       public IEnumerable<Matches> CreateMatchesForLeague(List<Team> teams)
        {
            List<Matches> matches = new List<Matches>();
            Matches matches1 = new Matches()
            {
                FirstTeam = _teamManager.Get(x => x.id == 1),
                SecondTeam = _teamManager.Get(x => x.id == 2),
                IsPlayed = false,


            };
            matches.Add(PlayMatch(matches1));

            return matches;



        }

        private Matches PlayMatch(Matches matches)
        {

            matches.ScoreFirstTeam = FakeData.NumberData.GetNumber(0, 5);

            matches.ScoreSecondTeam = FakeData.NumberData.GetNumber(0, 3);
            return new Matches();
        }
    }

   
}
