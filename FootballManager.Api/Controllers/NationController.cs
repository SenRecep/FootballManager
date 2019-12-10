using System.Web.Http.Description;
using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationController : BaseController
    {
        private readonly NationManager _nationManager;
        public NationController(INationService nation)
        {
            _nationManager = (NationManager)nation;
        }

        // GET: api/Nation
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _nationManager.GetAll(), true);

        // GET: api/Nation/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _nationManager.Get(x => x.id == id), true);
        }

        // POST: api/Nation/Create
        
        [HttpPost, Route("{Adress}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Nation value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _nationManager, true);
        }

        // PUT: api/Nation/Update/5
        [HttpPut, Route("{Adress}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Nation value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _nationManager, false);
        }

        // DELETE: api/Nation/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _nationManager.Delete(x => x.id == id);
            _nationManager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}