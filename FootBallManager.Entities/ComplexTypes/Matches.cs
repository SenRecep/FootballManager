using FootBallManager.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.ComplexTypes
{
    public class Matches
    {
        public ITeam FirstTeam { get; set; }
        public ITeam SecondTeam { get; set; }
        public int ScoreFirstTeam { get; set; }
        public int ScoreSecondTeam { get; set; }

    }
}
