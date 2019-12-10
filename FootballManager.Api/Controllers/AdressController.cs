using System.Collections.Generic;
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
        private readonly PostalcodeManager _postalcodeManager;
        public AdressController(IAdressesService Adress,IPostalcodeService postalcodeService)
        {
            _Adressmanager = (AdressManager)Adress;
            _postalcodeManager = (PostalcodeManager)postalcodeService;
        }

        // GET: api/Adress
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll()
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _Adressmanager.GetAllLoadPostalCode(_postalcodeManager), true);
        }

        // GET: api/Adress/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _Adressmanager.GetLoadPostalCode(id,_postalcodeManager), true);
        }

        // POST: api/Adress/Create
        
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
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _Adressmanager.Delete(x => x.id == id);
            _Adressmanager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}