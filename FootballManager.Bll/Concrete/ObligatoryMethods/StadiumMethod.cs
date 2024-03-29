﻿using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete.ObligatoryMethods
{
    public static class StadiumMethod
    {
        /// <summary>
        ///Create new Stadium 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Stadium CreateStadium(User user)
        {
            Stadium stadium = new Stadium
            {
                Capacity = 3000,
                Founded = DateTime.Now.Year,
                StadiumName = $"{user.TagName}'s stadium",
            };
            return stadium;
        }
    }
}
