using System;
using System.Collections.Generic;
using FootBallManager.Entities.ComplexTypes;

namespace FootBallManager.Entities.Abstract
{
    public interface ISeason
    {
        DateTime Date { get; set; }
        ICollection<League> Leagues { get; set; }
    }
}