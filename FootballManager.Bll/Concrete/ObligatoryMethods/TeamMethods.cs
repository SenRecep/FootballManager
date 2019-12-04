using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballManager.Bll.Concrete.ObligatoryMethods
{
    public static class TeamMethods
    {
        /// <summary>
        /// Create new Team for User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Team CreateTeam(User user)
        {
            Team team = new Team()
            {
                ClubName = $"{user.TagName}'s Team",
                Founded = DateTime.Now.Year,
                Stadium = StadiumMethod.CreateStadium(user),
                Players = PlayerMethod.CreatePlayers().ToList(),

        };
            
            return team;
        }

        /// <summary>
        /// Saving new Team to database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="teamManager"></param>
        /// <param name="stadiumManager"></param>
        /// <param name="playerManager"></param>
        /// <param name="playerSkillManager"></param>
        /// <param name="nationManager"></param>
        /// <returns></returns>
        public static Team CreateFinishedTeam(
            User user,
            TeamManager teamManager,
            StadiumManager stadiumManager,
            PlayerManager playerManager,
            PlayerSkillManager playerSkillManager,
            NationManager nationManager)
        {
            Team team = CreateTeam(user);
            stadiumManager.Add(team.Stadium);
            stadiumManager.Save();
            foreach (Player player in team.Players)
            {

                nationManager.Add(player.Nation);
                nationManager.Save();
                playerSkillManager.Add(player.PlayerSkill);
                playerSkillManager.Save();
                
                playerManager.Add(player);
               
                playerManager.Save();
                
            }
            
            teamManager.Add(team);
            teamManager.Save();
            return team;
        }
    }
}
