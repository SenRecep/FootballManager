using System.Collections.Generic;
using FootBallManager.Entities.ComplexTypes;
using FootBallManager.Entities.Concrete;

namespace FootBallManager.Entities.Abstract
{
    public interface ILeague
    {
        List<Matches> Matches { get; set; }
        Season Season { get; set; }
        int? Seasonid { get; set; }
        List<Team> Teams { get; set; }
    }
}