using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete.ObligatoryMethods
{
    public static class CoachMethod
    {
        public static Coach CreateCoach()
        {


            Coach coach = new Coach();

            coach.Firstname = FakeData.NameData.GetMaleFirstName();
                coach.LastName = FakeData.NameData.GetSurname();
            coach.Age = FakeData.NumberData.GetNumber(40, 65);
            coach.Nation = NationMethods.CreateNation();
            coach.WeeklyPaid = FakeData.NumberData.GetNumber(10000, 50000);
            coach.CoachSkill = CoachSkillMethod.CreateCoachSkill();

            return coach;
        }
    }
}
