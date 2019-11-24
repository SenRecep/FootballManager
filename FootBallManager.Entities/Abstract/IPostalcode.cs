using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.Abstract
{
   public interface IPostalcode
    {
        string City { get; set; }
        int PostalCode { get; set; }
    }
}
