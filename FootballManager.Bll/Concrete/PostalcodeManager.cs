using FootballManager.Bll.Abstract;
using FootballManager.Dal.Abstract;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using static FootballManager.Bll.Concrete.Validation.ValidationIsNullOrWhitespace;

namespace FootballManager.Bll.Concrete
{

   public class PostalcodeManager : EntityManager<Postalcode>, IPostalcodeService
    {
    public PostalcodeManager(IPostalcodeDal repostory) : base(repostory) { }

        public bool PostalCodeValidation(Postalcode postalcode)
        {
            if (string.IsNullOrWhiteSpace(ValidationIsNullOrEmpty(postalcode)))
                if (CityLenghtIs4(postalcode))
                {
                    return true;
                }

            return false;
        }

        public bool CityLenghtIs4(Postalcode postalcode)
        {
            if (postalcode.City.Length == 4)
            {
                return true;
            }
            else return false;
        }
        public bool AdressValidation(Adress adress)
        {
            if (string.IsNullOrWhiteSpace(ValidationIsNullOrEmpty(adress)))
            {
                PostalCodeValidation(adress.PostalCode);

                return true;
            }
            return false;
        }

    }
}
