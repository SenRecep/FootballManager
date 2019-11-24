using FootballManager.Bll.Abstract.Services;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete.Validation.Services
{
    public class ValidationTrophy : IValidationTrophy
    {
        public void IsValidTrophy(Trophy trophy)
        {
            if (trophy.Year >  DateTime.Now.Year)
            {
                throw new NotSupportedException("Venligst indtast en valid år");
            }
            if (trophy.Place <= 0)
            {
                throw new NotSupportedException("Et holds placering kan ikke være 0 eller et minus tal");
            }
        }

       
    }
}
