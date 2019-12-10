using FootballManager.Bll.Abstract;
using FootballManager.Dal.Abstract;
using FootBallManager.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete
{
    public class LeagueTeamManager : EntityManager<LeagueTeam>, ILeagueTeamService
    {
        public LeagueTeamManager(ILeagueTeamDal repostory) : base(repostory) { }
    }
}
