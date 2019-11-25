using FootballManager.Bll.Abstract;
using FootballManager.Dal.Abstract;
using FootBallManager.Entities.ComplexTypes;

namespace FootballManager.Bll.Concrete
{
    public class SeasonManager : EntityManager<Season>, ISeasonService
    {
        public SeasonManager(ISeasonDal repostory) : base(repostory) { }
    }
}
