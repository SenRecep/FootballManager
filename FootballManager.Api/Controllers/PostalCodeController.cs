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
    public class PostalcodeController : BaseController
    {
        private readonly PostalcodeManager _Postalcodemanager;
        public PostalcodeController(IPostalcodeService Postalcode)
        {
            _Postalcodemanager = (PostalcodeManager)Postalcode;
        }

        // GET: api/Postalcode
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _Postalcodemanager.GetAll(), true);

        // GET: api/Postalcode/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _Postalcodemanager.Get(x => x.id == id), true);
        }

        // POST: api/Postalcode/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{Postalcode}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Postalcode value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _Postalcodemanager, true);
        }

        // PUT: api/Postalcode/Update/5
        [HttpPut, Route("{Postalcode}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Postalcode value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _Postalcodemanager, false);
        }

        // DELETE: api/Postalcode/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _Postalcodemanager.Delete(x => x.id == id);
            _Postalcodemanager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}