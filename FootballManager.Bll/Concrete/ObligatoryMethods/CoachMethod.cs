using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete.ObligatoryMethods
{
   public static class CoachMethod
    {
        public static Coach CreateCoach(User user)
        {
            Coach coach = new Coach()
            {
                
            };
            return coach;
        }
    }
}
