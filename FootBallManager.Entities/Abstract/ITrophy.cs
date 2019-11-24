using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootBallManager.Entities.Abstract
{
    public interface ITrophy
    {
        int Year { get; set; }
        int Place { get; set; }
        Team team { get; set; }
        int teamid { get; set; }
    }
}
