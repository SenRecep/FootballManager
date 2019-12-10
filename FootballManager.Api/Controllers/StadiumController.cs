using System.Web.Http.Description;
using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using Microsoft.AspNetCore.Cors;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;
using Microsoft.AspNetCore.Mvc;
using FootBallManager.Entities.Concrete;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : BaseController
    {
        private readonly StadiumManager _stadiumManager;
        public StadiumController(IStadiumService stadium)
        {
            _stadiumManager = (StadiumManager)stadium;
        }

        // GET: api/Stadium
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _stadiumManager.GetAll(), true);

        // GET: api/Stadium/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _stadiumManager.Get(x => x.id == id), true);
        }

        // POST: api/Stadium/Create
        
        [HttpPost, Route("{Adress}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Stadium value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _stadiumManager, true);
        }

        // PUT: api/Stadium/Update/5
        [HttpPut, Route("{Adress}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Stadium value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _stadiumManager, false);
        }

        // DELETE: api/Stadium/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _stadiumManager.Delete(x => x.id == id);
            _stadiumManager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}