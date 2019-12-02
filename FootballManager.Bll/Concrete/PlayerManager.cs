using FootballManager.Bll.Abstract;
using FootballManager.Dal.Abstract;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete
{
    public class PlayerManager : EntityManager<Player>, IPlayerService
    {
        public PlayerManager(IPlayerDal repostory) : base(repostory) { }

        public void Add(List<Player> players)
        {
            players.ForEach(x=> _repostory.Add(x));
        }
    }
}
