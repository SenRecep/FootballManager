using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using FootBallManager.Entities.ComplexTypes;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.ComplexTypes
{
    public class League :EntityBase, ILeague
    {
        public Season Season { get; set; }
        public int? Seasonid { get; set; }

        public string Name{ get; set; }

        public virtual List<LeagueTeam> LeagueTeams { get; set; }
        public virtual List<Matches> Matches { get; set; }
    }
}
