using FootBallManager.Entities.ComplexTypes;
using FootBallManager.Entities.Concrete;

namespace FootBallManager.Entities.Abstract
{
    public interface ILeagueTeam
    {
        League League { get; set; }
        int Leagueid { get; set; }
        Team Team { get; set; }
        int Teamid { get; set; }
    }
}