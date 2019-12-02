using FootballManager.Bll.Abstract;
using FootballManager.Dal.Abstract;
using FootBallManager.Entities.ComplexTypes;

namespace FootballManager.Bll.Concrete
{
    public class LeagueManager : EntityManager<League>, ILeagueService
    {
        public LeagueManager(ILeagueDal repostory) : base(repostory) { }
    }
}
