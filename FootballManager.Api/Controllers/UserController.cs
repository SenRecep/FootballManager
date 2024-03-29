﻿using FootballManager.Api.Helper;
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
using FootballManager.Bll.Concrete.ObligatoryMethods;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly UserManager _usermanager;
        private readonly AdressManager _adressmanager;
        private readonly PostalcodeManager _postalcodeManager;
        private readonly TeamManager _teamManager;
        private readonly NationManager _nationManager;
        private readonly PlayerSkillManager _playerskillManager;
        private readonly PlayerManager _playerManager;
        private readonly StadiumManager _stadiumManager;
        private readonly CoachManager _coachManager;
        private readonly CoachSkillManager _coachSkillManager;


        public UserController(
            IUserService user,
            IAdressesService adressesService,
            IPostalcodeService postalcodeService,
            ITeamService teamService,
            INationService nationService,
            IPlayerSkillService playskillService,
            IPlayerService playerService,
            IStadiumService stadiumService,
            ICoachService coachService,
            ICoachSkillService coachSkillService)
        {
            _usermanager = (UserManager)user;
            _adressmanager = (AdressManager)adressesService;
            _postalcodeManager = (PostalcodeManager)postalcodeService;
            _teamManager = (TeamManager)teamService;
            _nationManager = (NationManager)nationService;
            _playerskillManager = (PlayerSkillManager)playskillService;
            _playerManager = (PlayerManager)playerService;
            _stadiumManager = (StadiumManager)stadiumService;
            _coachManager = (CoachManager)coachService;
            _coachSkillManager = (CoachSkillManager)coachSkillService;
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

        // GET: api/User/Detail/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("detail/{id}"), ResponseType(typeof(User))]
        public EntityHttpResponse GetDetail(int id)
        {
            User  user = _usermanager.Get(x => x.id == id);
            if (user is null)
            {
                return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, false);
            }
            else
                return new EntityHttpResponse(System.Net.HttpStatusCode.OK, user, true);
            
        }



        // POST: api/User/Create
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
        [HttpGet("Register/{email}/{password}/{username}"), ResponseType(typeof(void))]
        public EntityHttpResponse Register(string email, string password, string username)
        {
            IUser user = null;
            StringBuilder error = new StringBuilder();
            user = _usermanager.Get(x => x.TagName == username);
            if (user != null)
                error.AppendLine("Denne brugernavn er allerede i brug");
            user = _usermanager.Get(x => x.Email == email);
            if (user != null)
                error.AppendLine("Denne email er allerede i brug");
            //todo: Check om Password kvalitet er god nok
            if (user != null)
            {
                return new EntityHttpResponse(System.Net.HttpStatusCode.BadRequest, error.ToString(), false);
            }
            else
            {
                try
                {
                    User newuser = new User()
                    {
                        TagName = username,
                        Email = email,
                        Password = password,
                    };
                    newuser.Team = TeamMethods.CreateFinishedTeam(
                                  newuser,
                                  _teamManager,
                                  _stadiumManager,
                                  _playerManager,
                                  _playerskillManager,
                                  _nationManager
                                  //_coachManager,
                                  /*_coachSkillManager*/);


                    _usermanager.Add(newuser);
                    _usermanager.Save();
                }
                catch (Exception E)
                {
                    return new EntityHttpResponse(System.Net.HttpStatusCode.InternalServerError, "Der kunne desværre ikke oprettes en forbindelse til databasen. Prøv venligst igen senere.", false);
                }
                return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
            }
        }

        //[HttpGet("Register/{email}/{password}/{username}"), ResponseType(typeof(void))]
        //public EntityHttpResponse GetAccountInfo(int id)
        //{
        //    IUser user = null;
        //    StringBuilder error = new StringBuilder();
        //    user = _usermanager.Get(x => x.id == id);
        //    if (user is null)
        //    {
        //        error.AppendLine("Denne bruger findes ikke.");
        //        return new EntityHttpResponse(System.Net.HttpStatusCode.BadRequest, error.ToString(), false);

        //    }

        //        return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        //    }
    }



}

