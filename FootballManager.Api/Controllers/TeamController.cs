using System.Web.Http.Description;
using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : BaseController
    {
        private readonly TeamManager _teamManager;
        public TeamController(ITeamService team)
        {
            _teamManager = (TeamManager)team;
        }

        // GET: api/Team
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _teamManager.GetAll(), true);

        // GET: api/Team/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _teamManager.Get(x => x.id == id), true);
        }

        // POST: api/Team/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{Team}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Team value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _teamManager, true);
        }

        // PUT: api/Team/Update/5
        [HttpPut, Route("{Team}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Team value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _teamManager, false);
        }

        // DELETE: api/Team/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _teamManager.Delete(x => x.id == id);
            _teamManager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}