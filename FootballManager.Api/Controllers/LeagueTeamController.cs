using System.Web.Http.Description;
using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;
using Microsoft.AspNetCore.Mvc;
using FootBallManager.Entities.ComplexTypes;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueTeamController : BaseController
    {
        private readonly LeagueTeamManager _LeagueTeamManager;
        public LeagueTeamController(ILeagueTeamService LeagueTeam)
        {
            _LeagueTeamManager = (LeagueTeamManager)LeagueTeam;
        }

        // GET: api/LeagueTeam
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _LeagueTeamManager.GetAll(), true);

        // GET: api/LeagueTeam/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _LeagueTeamManager.Get(x => x.id == id), true);
        }

        // POST: api/LeagueTeam/Create

        [HttpPost, Route("{LeagueTeam}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] LeagueTeam value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _LeagueTeamManager, true);
        }

        // PUT: api/LeagueTeam/Update/5
        [HttpPut, Route("{LeagueTeam}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] LeagueTeam value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _LeagueTeamManager, false);
        }

        // DELETE: api/LeagueTeam/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _LeagueTeamManager.Delete(x => x.id == id);
            _LeagueTeamManager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}