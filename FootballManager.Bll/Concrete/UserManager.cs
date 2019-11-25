using FootballManager.Bll.Abstract;
using FootballManager.Dal.Abstract;
using FootBallManager.Entities.Concrete;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete
{
    public class UserManager : EntityManager<User>, IUserService
    {
        public UserManager(IUserDal repostory) : base(repostory) { }

        public ICollection<User> GetAllLoadAdress(AdressManager adressManager,PostalcodeManager postalcodeManager)
        {
            var users = GetAll();
            ((List<User>)users).ForEach(item=> {
                item.Adress = adressManager.GetLoadPostalCode(item.Adressid,postalcodeManager);
            });
            return users;
        }

        public User GetLoadAdress(int id, AdressManager adressManager, PostalcodeManager postalcodeManager)
        {
            User user = Get(x=>x.id==id);
            user.Adress= adressManager.GetLoadPostalCode(user.Adressid, postalcodeManager);
            return user;
        }
    }
}