using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Description;
using System.Linq;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;
using static FootballManager.Bll.Helpers.ToPasswordRepository;
using FootBallManager.Entities.Abstract;
using System.Text;
using System;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly UserManager _usermanager;
        private readonly AdressManager _adressmanager;
        private readonly PostalcodeManager _postalcodeManager;
        private readonly StadiumManager _stadiumManager;
        private readonly TeamManager _teamManager;
        private readonly CoachManager _coachManager;
        private readonly NationManager _nationManager;

        public UserController(
            IUserService user,
            IAdressesService adressesService,
            IPostalcodeService postalcodeService,
            IStadiumService stadiumService,
            ITeamService teamService,
            ICoachService coachService,
            INationService nationService)
        {
            _usermanager = (UserManager)user;
            _adressmanager = (AdressManager)adressesService;
            _postalcodeManager = (PostalcodeManager)postalcodeService;
            _stadiumManager = (StadiumManager)stadiumService;
            _teamManager = (TeamManager)teamService;
            _coachManager = (CoachManager)coachService;
            _nationManager = (NationManager)nationService;
        }

        // GET: api/User
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll()
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _usermanager.GetAllLoadAdress(_adressmanager, _postalcodeManager), true);
        }

        // GET: api/User/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _usermanager.GetLoadAdress(id, _adressmanager, _postalcodeManager), true);
        }

        // POST: api/User/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{User}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] User value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _usermanager, true);
        }

        // PUT: api/User/Update/5
        [HttpPut, Route("{User}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] User value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _usermanager, false);
        }

        // DELETE: api/User/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _usermanager.Delete(x => x.id == id);
            _usermanager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }

        [HttpGet("Login/{email}/{password}"), ResponseType(typeof(User))]
        public EntityHttpResponse Login(string email, string password)
        {
            IUser user = _usermanager.Get(x => x.Email == email && x.Password == password);
            if (user != null)
                return new EntityHttpResponse(System.Net.HttpStatusCode.OK, user, true);
            return new EntityHttpResponse(System.Net.HttpStatusCode.BadRequest, "Ingen bruger med denne email eller adgangskode", false);

        }
        [HttpPost("Register/{email}/{password}/{username}"), ResponseType(typeof(void))]
        public EntityHttpResponse Register(string email, string password, string username, [FromBody] Adress adress)
        {
            IUser user = null;
            StringBuilder error = new StringBuilder();
            user = _usermanager.Get(x => x.TagName == username);
            if (user != null)
                error.AppendLine("Denne brugernavn er allerede i brug");
            user = _usermanager.Get(x => x.Email == email);
            if (user != null)
                error.AppendLine("Denne email er allerede i brug");
            //todo: Password kalitesi icin metod yaz ve kontrol ettir.
            if (user!=null)
            {
                return new EntityHttpResponse(System.Net.HttpStatusCode.BadRequest, error.ToString(), false);
            }
            else
            {
                _postalcodeManager.Add(adress.PostalCode);
                _adressmanager.Add(adress);

              

                IStadium stadium = new Stadium()
                {
                    Capacity=3000,
                    Founded=DateTime.Now.Year,
                    StadiumName=$"{username}s stadium"
                };
                _stadiumManager.Add((Stadium)stadium);

                INation nation = new Nation
                {
                    Nationality = "Danemark"
                };
                _nationManager.Add((Nation)nation);

                ICoachSkill coachSkill = new CoachSkill
                {
                     
                };

                ICoach coach = new Coach()
                {
                    Firstname = "Abdulla",
                    LastName = "Oksum",
                     Age = 39,
                      Nation = (Nation)nation,
                      WeeklyPaid =1000,
                      CoachSkill = (CoachSkill)coachSkill

                    // todo: buraya kadar gelmistik 27-11-2019
                };
                _coachManager.Add((Coach)coach);



                ITeam team = new Team()
                {
                    Founded=DateTime.Now.Year,
                    Stadium=(Stadium)stadium,
                    ClubName= $"{username}s Football Club",
                };
                _teamManager.Add((Team)team);
                IUser newuser = new User()
                {
                    TagName = username,
                    Email = email,
                    Password = password,
                    Adress = adress,
                    Team = (Team)team
                };


                //todo: Dal kisminda IUser almasini sagla
                _usermanager.Add((User)newuser);
                _usermanager.Save();

                return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
            }
        }
    }
}
