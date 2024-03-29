﻿using FootballManager.Bll.Abstract;
using FootballManager.Dal.Abstract;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete
{
   public class CoachManager : EntityManager<Coach>, ICoachService
    {
        public CoachManager(ICoachDal repostory) : base(repostory) { }
        
    }
}
