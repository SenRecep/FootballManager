﻿using FootBallManager.Entities.ComplexTypes;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.Abstract
{
   public interface ITeam
    {
        string ClubName { get; set; }
        int Founded { get; set; }
        Stadium Stadium { get; set; }
        int? Stadiumid { get; set; }
        List<Player> Players { get; set; }
        Coach Coach{ get; set; }
        int? Coachid { get; set; }
        List<Trophy> Trophies { get; set; }
        List<LeagueTeam> LeagueTeams { get; set; }
    }
}
