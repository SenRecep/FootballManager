using System.Web.Http.Description;
using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : BaseController
    {
        private readonly CoachManager _coachManager;
        public CoachController(ICoachService coach)
        {
            _coachManager = (CoachManager)coach;
        }

        // GET: api/Coach
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _coachManager.GetAll(), true);

        // GET: api/Coach/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _coachManager.Get(x => x.id == id), true);
        }

        // POST: api/Coach/Create
        
        [HttpPost, Route("{Coach}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Coach value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _coachManager, true);
        }

        

        // PUT: api/Coach/Update/5
        [HttpPut, Route("{Coach}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Coach value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _coachManager, false);
        }

        // DELETE: api/Coach/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _coachManager.Delete(x => x.id == id);
            _coachManager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}