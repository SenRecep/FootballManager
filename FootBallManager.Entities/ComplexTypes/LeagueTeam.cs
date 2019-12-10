using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.ComplexTypes
{
    public class LeagueTeam : EntityBase, ILeagueTeam
    {
        public int Teamid { get; set; }
        public Team Team { get; set; }
        public int Leagueid { get; set; }
        public League League { get; set; }
    }
}
