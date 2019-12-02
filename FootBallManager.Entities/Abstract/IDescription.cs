using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.Abstract
{
   public interface IDescription
    {
       
        Player Player { get; set; }
        int? Playerid { get; set; }
        string PlayerDescription { get; set; }
    }
}
