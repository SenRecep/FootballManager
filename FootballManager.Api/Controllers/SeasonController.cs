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
    public class SeasonController : BaseController
    {
        private readonly SeasonManager _seasonmanager;
        public SeasonController(ISeasonService Season)
        {
            _seasonmanager = (SeasonManager)Season;
        }

        // GET: api/Season
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll()
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _seasonmanager.GetAll(), true);
        }

        // GET: api/Season/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _seasonmanager.Get(x => x.id == id), true);
        }

        // POST: api/Season/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{Season}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Season value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _seasonmanager, true);
        }

        // PUT: api/Season/Update/5
        [HttpPut, Route("{Season}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Season value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _seasonmanager, false);
        }

        // DELETE: api/Season/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _seasonmanager.Delete(x => x.id == id);
            _seasonmanager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}