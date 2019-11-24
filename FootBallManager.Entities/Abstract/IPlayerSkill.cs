using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.Abstract
{
   public interface IPlayerSkill
    {
        
         Player Player { get; set; }
        
         int GoolKeeping { get; set; }
     
         int Defending { get; set; }
      
         int Technical { get; set; }
       
         int Attacking { get; set; }
      
         int Speed { get; set; }
    }
}
