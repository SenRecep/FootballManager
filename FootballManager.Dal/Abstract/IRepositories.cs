using FootballManager.Core.Dal;
using FootBallManager.Entities.Concrete;

namespace FootballManager.Dal.Abstract
{

        public interface IAdressDal : IEntityRepostory<Adress> { }
        public interface ICoachDal : IEntityRepostory<Coach> { }
        public interface ICoachSkillsDal : IEntityRepostory<CoachSkill> { }
        public interface IDescriptionDal : IEntityRepostory<Description> { }
        public interface INationDal : IEntityRepostory<Nation> { }
        public interface IPlayerDal : IEntityRepostory<Player> { }
        public interface IPlayerSkillDal : IEntityRepostory<PlayerSkill> { }
        public interface IPostalcodeDal : IEntityRepostory<Postalcode> { }
        public interface IStadiumDal : IEntityRepostory<Stadium> { }
        public interface ITeamDal : IEntityRepostory<Team> { }
        public interface ITrophyDal : IEntityRepostory<Trophy> { }
        public interface IUserDal : IEntityRepostory<User> { }
    
}
