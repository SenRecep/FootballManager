using FootBallManager.Entities.Abstract;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete.ObligatoryMethods
{
  public static class NationMethods
    {
        /// <summary>
        /// Return a new country
        /// </summary>
        /// <returns>new Country</returns>
        public static Nation CreateNation()
        {
            Nation nation = new Nation()
            {
                Nationality = FakeData.PlaceData.GetCountry()
            };
            return nation;
        }
    }
}
