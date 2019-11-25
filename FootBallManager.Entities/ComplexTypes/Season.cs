using FootBallManager.Entities.ComplexTypes;
using FootBallManager.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using FootballManager.Core.Entities;

namespace FootBallManager.Entities.ComplexTypes
{
    public class Season : EntityBase, ISeason
    {
        public DateTime Date { get; set; }
        public virtual ICollection<League> Leagues { get; set; }
    }
}
