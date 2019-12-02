using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootBallManager.Entities.ComplexTypes;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : BaseController
    {
        private readonly LeagueManager _Leaguemanager;
        public LeagueController(ILeagueService League)
        {
            _Leaguemanager = (LeagueManager)League;
        }

        // GET: api/League
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll()
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _Leaguemanager.GetAll(), true);
        }

        // GET: api/League/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _Leaguemanager.Get(x=>x.id==id),true);
        }

        // POST: api/League/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{League}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] League value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _Leaguemanager, true);
        }

        // PUT: api/League/Update/5
        [HttpPut, Route("{League}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] League value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _Leaguemanager, false);
        }

        // DELETE: api/League/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _Leaguemanager.Delete(x => x.id == id);
            _Leaguemanager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}