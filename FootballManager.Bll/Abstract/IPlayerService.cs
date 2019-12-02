using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Abstract
{
    public interface IPlayerService
    {
        void Add(List<Player> players);
    }
}
