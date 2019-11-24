using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.Abstract
{
   public interface IAdress
    {
        string Adresses { get; set; }
        Postalcode PostalCode { get; set; }
        int PostalCodeid { get; set; }
    }
}
