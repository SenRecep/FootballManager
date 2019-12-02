using FootballManager.Bll.Abstract;
using FootballManager.Dal.Abstract;
using FootBallManager.Entities.ComplexTypes;

namespace FootballManager.Bll.Concrete
{
    public class MatchesManager : EntityManager<Matches>, IMatchesService
    {
        public MatchesManager(IMatchesDal repostory) : base(repostory) { }
    }
}
