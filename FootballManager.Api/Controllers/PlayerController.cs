using System.Web.Http.Description;
using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using FootballManager.Api.Helper;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : BaseController
    {
        private readonly PlayerManager _playerManager;
        public PlayerController(IPlayerService player)
        {
            _playerManager = (PlayerManager)player;
        }

        // GET: api/Player
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _playerManager.GetAll(), true);

        // GET: api/Player/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _playerManager.Get(x => x.id == id), true);
        }

        // POST: api/Player/Create
        
        [HttpPost, Route("{Player}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] Player value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _playerManager, true);
        }

        // PUT: api/Player/Update/5
        [HttpPut, Route("{Player}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] Player value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _playerManager, false);
        }

        // DELETE: api/Player/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _playerManager.Delete(x => x.id == id);
            _playerManager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}