using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrophyController : BaseController
    {
        private readonly TrophyManager _trophyManager;
        public TrophyController(ITrophyService trophy)
        {
            _trophyManager = (TrophyManager)trophy;
        }

        // GET: api/Team
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _trophyManager.GetAll(), true);

        // GET: api/Trophy/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _trophyManager.Get(x => x.id == id), true);
        }

        // POST: api/Trophy/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{Trophy}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Trophy value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _trophyManager, true);
        }

        // PUT: api/Trophy/Update/5
        [HttpPut, Route("{Trophy}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Trophy value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _trophyManager, false);
        }

        // DELETE: api/Trophy/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _trophyManager.Delete(x => x.id == id);
            _trophyManager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}