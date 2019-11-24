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
    public class AdressController : BaseController
    {
        private readonly AdressManager _Adressmanager;
        public AdressController(IAdressesService Adress)
        {
            _Adressmanager = (AdressManager)Adress;
        }

        // GET: api/Adress
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _Adressmanager.GetAll(), true);

        // GET: api/Adress/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _Adressmanager.Get(x => x.id == id), true);
        }

        // POST: api/Adress/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{Adress}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Adress value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _Adressmanager, true);
        }

        // PUT: api/Adress/Update/5
        [HttpPut, Route("{Adress}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Adress value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _Adressmanager, false);
        }

        // DELETE: api/Adress/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _Adressmanager.Delete(x => x.id == id);
            _Adressmanager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}