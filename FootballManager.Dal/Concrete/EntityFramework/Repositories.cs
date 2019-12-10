using FootballManager.Dal.Abstract;
using FootballManager.Dal.Concrete.EntityFramework.Contexts;
using FootBallManager.Entities.ComplexTypes;
using FootBallManager.Entities.Concrete;

namespace FootballManager.Dal.Concrete.EntityFramework
{
    public class EfAdresstDal : EfEntityRepostoryBase<Adress, ManagerContext>, IAdressDal { }
    public class EfCoachtDal : EfEntityRepostoryBase<Coach, ManagerContext>, ICoachDal { }
    public class EfCoachSkillDal : EfEntityRepostoryBase<CoachSkill, ManagerContext>, ICoachSkillsDal { }
    public class EfDescriptionDal : EfEntityRepostoryBase<Description, ManagerContext>, IDescriptionDal { }
    public class EfNationDal : EfEntityRepostoryBase<Nation, ManagerContext>, INationDal { }
    public class EfPlayerDal : EfEntityRepostoryBase<Player, ManagerContext>, IPlayerDal { }
    public class EfPlayerSkillDal : EfEntityRepostoryBase<PlayerSkill, ManagerContext>, IPlayerSkillDal { }
    public class EfPostalcodeDal : EfEntityRepostoryBase<Postalcode, ManagerContext>, IPostalcodeDal { }
    public class EfStadiumDal : EfEntityRepostoryBase<Stadium, ManagerContext>, IStadiumDal { }
    public class EfTeamDal : EfEntityRepostoryBase<Team, ManagerContext>, ITeamDal { }
    public class EfTrophyDal : EfEntityRepostoryBase<Trophy, ManagerContext>, ITrophyDal { }
    public class EfUserDal : EfEntityRepostoryBase<User, ManagerContext>, IUserDal { }
    public class EfSeasonDal : EfEntityRepostoryBase<Season, ManagerContext>, ISeasonDal { }
    public class EfLeagueDal : EfEntityRepostoryBase<League, ManagerContext>, ILeagueDal { }
    public class EfMatchesDal : EfEntityRepostoryBase<Matches, ManagerContext>, IMatchesDal { }
    public class EfLeagueTeamDal : EfEntityRepostoryBase<LeagueTeam, ManagerContext>, ILeagueTeamDal { }
}
