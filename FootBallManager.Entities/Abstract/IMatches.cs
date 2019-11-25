using System;
using FootBallManager.Entities.Abstract;
using FootBallManager.Entities.Concrete;

namespace FootBallManager.Entities.Abstract
{
    public interface IMatches
    {
        DateTime Date { get; set; }
        Team FirstTeam { get; set; }
        bool IsPlayed { get; set; }
        int ScoreFirstTeam { get; set; }
        int ScoreSecondTeam { get; set; }
        Team SecondTeam { get; set; }
    }
}