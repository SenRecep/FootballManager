using FootballManager.Api.Controllers;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Abstract.Services;
using FootballManager.Bll.Concrete;
using FootballManager.Dal.Concrete.EntityFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Api.Test.TrophyControllerServiceTest
{
   public class GetAllTrophy
    {
        [Test]
        public void ReturnNullNoTrophyExist()
        {
            //Arrance
            //TrophyController trophy = new TrophyController(new TrophyManager(new EfTrophyDal()));
            ////ACT
            //trophy = null;
            ////Assert
            //Assert.AreEqual(trophy, trophy);
        }
    }
}
