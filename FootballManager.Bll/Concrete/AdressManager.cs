using FootballManager.Bll.Abstract;
using FootballManager.Dal.Abstract;
using FootBallManager.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete
{
    public class AdressManager : EntityManager<Adress>, IAdressesService
    {
        public AdressManager(IAdressDal repostory) : base(repostory) { }

        public ICollection<Adress> GetAllLoadPostalCode(PostalcodeManager postalcodeManager)
        {
            var adresses = GetAll();
            ((List<Adress>)adresses).ForEach(item =>
            {
                item.PostalCode = postalcodeManager.Get(x => x.id == item.PostalCodeid);
            });
            return adresses;
        }

        public Adress GetLoadPostalCode(int? id, PostalcodeManager postalcodeManager)
        {
            var adress = Get(x => x.id == id);
            if (adress != null)
                adress.PostalCode = postalcodeManager.Get(item => item.id == adress.id);
            return adress;
        }
    }
}
