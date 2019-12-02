using System.Web.Http.Description;
using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootBallManager.Entities.ComplexTypes;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : BaseController
    {
        private readonly MatchesManager _matchesmanager;
        public MatchesController(IMatchesService Matches)
        {
            _matchesmanager = (MatchesManager)Matches;
        }

        // GET: api/Matches
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll()
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _matchesmanager.GetAll(), true);
        }

        // GET: api/Matches/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _matchesmanager.Get(x => x.id == id), true);
        }

        // POST: api/Matches/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{Matches}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Matches value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _matchesmanager, true);
        }

        // PUT: api/Matches/Update/5
        [HttpPut, Route("{Matches}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Matches value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _matchesmanager, false);
        }

        // DELETE: api/Matches/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _matchesmanager.Delete(x => x.id == id);
            _matchesmanager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}