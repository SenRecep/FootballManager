using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.Abstract
{
    public interface IPlayer
    {
         string Firstname { get; set; }
         string LastName { get; set; }
         Adress Adress { get; set; }
         int Adressid { get; set; }
         string PhoneNumber { get; set; }
         string Email { get; set; }
         int Age { get; set; }
         double Height { get; set; }
         double Weight { get; set; }
         Nation Nation { get; set; }
         int Nationid { get; set; }
         string Position { get; set; }
         string Foot { get; set; }
         double WeeklyPaid { get; set; }
         double MarketPriceValue { get; set; }
         PlayerSkill PlayerSkill { get; set; }
         int? PlayerSkillid { get; set; }
         List<Description> Descriptions { get; set; }
         int Number { get; set; }
         Team Team { get; set; }
         int? Teamid { get; set; }
    }
}
