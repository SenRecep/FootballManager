using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.Abstract
{
   public interface ICoach
    {
        string Firstname { get; set; }
        string LastName { get; set; }

        int Age { get; set; }
        Nation Nation { get; set; }
        int Nationid { get; set; }

        double WeeklyPaid { get; set; }
        CoachSkill CoachSkill { get; set; }

    }
}
