using System.Web.Http.Description;
using FootballManager.Bll.Concrete;
using FootBallManager.Entities.Abstract;
using FootBallManager.Entities.Concrete;
using Microsoft.AspNetCore.Cors;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;
using FootballManager.Api.Helper;
using Microsoft.AspNetCore.Mvc;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerSkillController : BaseController
    {
        private readonly PlayerSkillManager _playerSkillManager;
        public PlayerSkillController(IPlayerSkill playerSkill)
        {
            _playerSkillManager = (PlayerSkillManager)playerSkill;
        }

        // GET: api/PlayerSkill
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _playerSkillManager.GetAll(), true);

        // GET: api/PlayerSkill/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _playerSkillManager.Get(x => x.id == id), true);
        }

        // POST: api/PlayerSkill/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{Adress}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] PlayerSkill value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _playerSkillManager, true);
        }

        // PUT: api/PlayerSkill/Update/5
        [HttpPut, Route("{Adress}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] PlayerSkill value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _playerSkillManager, false);
        }

        // DELETE: api/PlayerSkill/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(void))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _playerSkillManager.Delete(x => x.id == id);
            _playerSkillManager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}