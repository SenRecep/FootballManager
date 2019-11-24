using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Abstract.Services
{
    public interface IValidationTrophy
    {
        void IsValidTrophy(Trophy trophy);
    }
}
