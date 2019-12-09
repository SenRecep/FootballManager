using System;
using System.Collections.Generic;
using System.Web.Http.Description;
using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootballManager.Bll.Concrete.ObligatoryMethods;
using FootballManager.Bll.Helpers;
using FootballManager.Dal.Abstract;
using FootballManager.Dal.Concrete.EntityFramework;
using FootBallManager.Entities.Abstract;
using FootBallManager.Entities.ComplexTypes;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : BaseController
    {
        private readonly SeasonManager _seasonmanager;
        private readonly LeagueManager _leagueManager;
        private readonly TeamManager _teamManager;
        public SeasonController(ISeasonService Season, ILeagueService league, ITeamService team)
        {
            _seasonmanager = (SeasonManager)Season;
            _leagueManager = (LeagueManager)league;
            _teamManager = (TeamManager)team;
        }

        // GET: api/Season
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll()
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _seasonmanager.GetAll(), true);
        }

        // GET: api/Season/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _seasonmanager.Get(x => x.id == id), true);
        }

        // POST: api/Season/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{Season}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Season value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _seasonmanager, true);
        }

        // PUT: api/Season/Update/5
        [HttpPut, Route("{Season}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Season value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _seasonmanager, false);
        }

        // DELETE: api/Season/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _seasonmanager.Delete(x => x.id == id);
            _seasonmanager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }


        // DELETE: api/Season/CreateSeason
        [HttpGet("Season"), ResponseType(typeof(void))]
        public EntityHttpResponse CreateSeason()
        {
            ISeason season = new Season()
            {
                Date = DateTime.Now,

            };
                try
                {
                League Liga = new League()
                {
                    Season = (Season)season,
                };
                Liga.Teams.Add(_teamManager.Get(x=> x.IsActive == true));

                List<Matches> matches = new List<Matches>();
                Matches matches1 = new Matches()
                {
                    FirstTeam = _teamManager.Get(x => x.id == 1),
                    SecondTeam = _teamManager.Get(x => x.id == 2),
                    IsPlayed = true,
                    ScoreFirstTeam = 1,
                    ScoreSecondTeam = 2
                    ,
                     

                };
                
                return new EntityHttpResponse(System.Net.HttpStatusCode.OK, season, true);      
                }
                catch (Exception E)
                {
                    return new EntityHttpResponse(System.Net.HttpStatusCode.InternalServerError, "Der kunne ikke oprettes en ny sæson.", false);
                }
              
            }
        }










    }
