using FootballManager.Bll.Concrete;
using FootBallManager.Entities.Abstract;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Abstract
{
    public interface IUserService
    {
        ICollection<User> GetAllLoadAdress(AdressManager adressManager, PostalcodeManager postalcodeManager);
        User GetLoadAdress(int id,AdressManager adressManager,PostalcodeManager postalcodeManager);
    }
}
