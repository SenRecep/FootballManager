using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.Abstract
{
   public interface IStadium
    {
        string StadiumName { get; set; }
        int Capacity { get; set; }

        int Founded { get; set; }
    }
}
