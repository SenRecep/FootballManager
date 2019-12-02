using FootballManager.Api.Helper;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionController : BaseController
    {
        private readonly DescriptionManager _descriptionManager;
        public DescriptionController(IDescriptionService description)
        {
            _descriptionManager = (DescriptionManager)description;
        }

        // GET: api/Description
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _descriptionManager.GetAll(), true);

        // GET: api/Description/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _descriptionManager.Get(x => x.id == id), true);
        }

        // POST: api/Description/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{Description}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Description value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _descriptionManager, true);
        }

        // PUT: api/Description/Update/5
        [HttpPut, Route("{Description}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Description value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _descriptionManager, false);
        }

        // DELETE: api/Description/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _descriptionManager.Delete(x => x.id == id);
            _descriptionManager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}