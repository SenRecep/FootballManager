using FootBallManager.Entities.Abstract;
using FootBallManager.Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete.ObligatoryMethods
{
    public static class PlayerMethod
    {
        public static Player CreatePlayer()
        {
            Player player = new Player
            {
                Firstname = FakeData.NameData.GetMaleFirstName(),
                LastName = FakeData.NameData.GetSurname(),
                Age = FakeData.NumberData.GetNumber(18, 36),
                Foot = FakeData.BooleanData.GetBoolean() == true ? "Right" : "Left",
                Height = FakeData.NumberData.GetNumber(155, 200),
                Nation = NationMethods.CreateNation(),
                Weight = FakeData.NumberData.GetNumber(55, 88),

            };
            player.MarketPriceValue = player.Age > 32 ? FakeData.NumberData.GetNumber(200000, 5000000) : FakeData.NumberData.GetNumber(3000000, 8000000);
            player.WeeklyPaid = player.Age > 32 ? FakeData.NumberData.GetNumber(1000, 5000) : FakeData.NumberData.GetNumber(30000, 80000);
            return player;
        }
        public static IEnumerable<Player> CreatePlayers()
        {
            Array positions = Enum.GetValues(typeof(Position));
            for (int i = 0; i < 11; i++)
            {
                Player player = CreatePlayer();
                for (int j = 0; j < positions.Length; j++)
                {
                    object value = positions.GetValue(j);
                    player.Position = (Position)value;
                    player.PlayerSkill = PlayerSkillMethods.CreatePayerSkills(player.Position);
                }
                yield return player;
            }
        }
    }
}
