using FootballManager.Bll.Concrete;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Abstract
{
    public interface IAdressesService
    {
        ICollection<Adress> GetAllLoadPostalCode(PostalcodeManager postalcodeManager);
        Adress GetLoadPostalCode(int? id,PostalcodeManager postalcodeManager);
    }
}
