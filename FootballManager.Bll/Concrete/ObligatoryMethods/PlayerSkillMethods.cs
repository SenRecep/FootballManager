using FootBallManager.Entities.Abstract;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete.ObligatoryMethods
{
    public static class PlayerSkillMethods
    {


        public static PlayerSkill CreatePayerSkills(Position position)
        {
            PlayerSkill playerSkill = null;
            switch (position)
            {
                case Position.Goolkeeper:
                    playerSkill = GoalKeeperSkills();
                    break;
                case Position.Attacker:
                    playerSkill = AttackerSkills();
                    break;
                case Position.Defensive:
                    playerSkill = DefensiveSkills();
                    break;
                case Position.MiddelField:
                    playerSkill = MiddelFielsSkills();
                    break;
            }
            return playerSkill;
        }
        /// <summary>
        /// Given skills for Goalkepers
        /// </summary>
        /// <returns></returns>
        public static PlayerSkill GoalKeeperSkills()
        {
            return new PlayerSkill()
            {
                GoolKeeping = FakeData.NumberData.GetNumber(8, 20),
                Defending = FakeData.NumberData.GetNumber(0, 4),
                Technical = FakeData.NumberData.GetNumber(0, 4),
                Attacking = FakeData.NumberData.GetNumber(0, 4),
                Speed = FakeData.NumberData.GetNumber(5, 10)
            };
            /// <summary>
            /// Given skills for Defensive player
            /// </summary>
            /// <returns></returns>
        }
        public static PlayerSkill DefensiveSkills()
        {
            return new PlayerSkill()
            {
                GoolKeeping = FakeData.NumberData.GetNumber(0, 6),
                Defending = FakeData.NumberData.GetNumber(8, 20),
                Technical = FakeData.NumberData.GetNumber(5, 10),
                Attacking = FakeData.NumberData.GetNumber(3, 7),
                Speed = FakeData.NumberData.GetNumber(5, 10)
            };
        }
        /// <summary>
        /// Given skills for Middelfield player
        /// </summary>
        /// <returns></returns>
        public static PlayerSkill MiddelFielsSkills()
        {
            return new PlayerSkill()
            {
                GoolKeeping = FakeData.NumberData.GetNumber(0, 4),
                Defending = FakeData.NumberData.GetNumber(4,12),
                Technical = FakeData.NumberData.GetNumber(8, 20),
                Attacking = FakeData.NumberData.GetNumber(4, 13),
                Speed = FakeData.NumberData.GetNumber(5, 10)
            };
        }

        /// <summary>
        /// Given skills for striker
        /// </summary>
        /// <returns></returns>
        public static PlayerSkill AttackerSkills()
        {
            return new PlayerSkill()
            {
                GoolKeeping = FakeData.NumberData.GetNumber(0, 6),
                Defending = FakeData.NumberData.GetNumber(1, 6),
                Technical = FakeData.NumberData.GetNumber(5,10),
                Attacking = FakeData.NumberData.GetNumber(8, 20),
                Speed = FakeData.NumberData.GetNumber(5, 10)
            };

        }
    }
}
