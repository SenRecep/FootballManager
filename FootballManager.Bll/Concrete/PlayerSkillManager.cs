using FootballManager.Bll.Abstract;
using FootballManager.Dal.Abstract;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete
{
    public class PlayerSkillManager : EntityManager<PlayerSkill>, IPlayerSkillService
    {
        public PlayerSkillManager(IPlayerSkillDal repostory) : base(repostory) { }
    }
}
