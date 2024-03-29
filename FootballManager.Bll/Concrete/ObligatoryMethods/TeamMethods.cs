﻿using FootBallManager.Entities.Concrete;
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
                
              //Coach = CoachMethod.CreateCoach()
                
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
        /// <param name="coachManager"></param>
        /// <param name="coachSkillManager"></param>
        /// <returns></returns>
        public static Team CreateFinishedTeam(
            User user,
            TeamManager teamManager,
            StadiumManager stadiumManager,
            PlayerManager playerManager,
            PlayerSkillManager playerSkillManager,
            NationManager nationManager
           // CoachManager coachManager,
            //CoachSkillManager coachSkillManager
          
            )
        {
            Team team = CreateTeam(user);

           // coachSkillManager.Add(team.Coach.CoachSkill);
            //coachSkillManager.Save();
              //  coachManager.Add(team.Coach);
                //coachManager.Save();
           
            stadiumManager.Add(team.Stadium);
            stadiumManager.Save();
            teamManager.Add(team);
            teamManager.Save();
            team.Players = PlayerMethod.CreatePlayers().ToList();
            foreach (Player player in team.Players)
            {
                nationManager.Add(player.Nation);
                nationManager.Save();
                playerSkillManager.Add(player.PlayerSkill);
                playerSkillManager.Save();
                playerManager.Add(player);
                playerManager.Save();
            }
            teamManager.Save();
            return team;

        }
    }
}
