using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Description;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;
namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly UserManager _usermanager;
        public UserController(IUserService user)
        {
            _usermanager = (UserManager)user;
        }

        // GET: api/User
        [HttpGet, ResponseType(typeof(string))] 
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _usermanager.GetAll(), true);

        // GET: api/User/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))] 
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _usermanager.Get(x => x.id == id), true);
        }

        // POST: api/User/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{User}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] User value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _usermanager, true);
        }

        // PUT: api/User/Update/5
        [HttpPut, Route("{User}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] User value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _usermanager, false);
        }

        // DELETE: api/User/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))] 
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _usermanager.Delete(x => x.id == id);
            _usermanager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}
