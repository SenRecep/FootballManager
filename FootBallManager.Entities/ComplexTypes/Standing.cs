using FootBallManager.Entities.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.ComplexTypes
{
    class Standing
    {
        public ICollection<Team> Teams { get; set; }
        Trophy tro = new Trophy()
        {
            Place = 1,
            Year = 2019,
            IsActive = true

        };
        
        
    }









   
}
