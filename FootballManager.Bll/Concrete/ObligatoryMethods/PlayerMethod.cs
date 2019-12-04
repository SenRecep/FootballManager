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
        /// <summary>
        /// Creating new player
        /// </summary>
        /// <returns></returns>
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
        static Random random = new Random();
        static List<int> numbers;
        public static int playerNumber()
        {
            A:
            int number = random.Next(1,100);
            if (numbers.Contains(number))
                goto A;
            numbers.Add(number);
            return number;
        }
        /// <summary>
        /// Creating a new Players and return them in list
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Player> CreatePlayers()
        {
            Array positions = Enum.GetValues(typeof(Position));
            for (int i = 0; i < positions.Length; i++)
            {
                numbers = new List<int>();
                object value = positions.GetValue(i);
                int count = (int)value;
                for (int j = 0; j < (int)value; j++)
                {
                    Player player = CreatePlayer();
                    player.Number = playerNumber();
                    player.Position = (Position)value;
                    player.PlayerSkill = PlayerSkillMethods.CreatePayerSkills(player.Position);
                    yield return player;
                }

            }

        }
    }
}
