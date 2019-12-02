using FootballManager.Core.Entities;
using FootBallManager.Entities.Abstract;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.ComplexTypes
{
    public partial class Matches : EntityBase, IMatches
    {
        public DateTime Date { get; set; }
        public Team FirstTeam { get; set; }
        public Team SecondTeam { get; set; }
        public int ScoreFirstTeam { get; set; }
        public int ScoreSecondTeam { get; set; }
        public bool IsPlayed { get; set; }
    }
}
