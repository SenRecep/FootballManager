using Microsoft.AspNetCore.Mvc;
using FootballManager.Api.Helper;
using FootBallManager.Entities.Concrete;
using FootballManager.Bll.Abstract;
using System.Web.Http.Description;
using FootballManager.Bll.Concrete;
using Microsoft.AspNetCore.Cors;
using static FootballManager.Api.Helper.ExeptionErrorMesaageFromApi;

namespace FootballManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachSkillController : BaseController
    {
        private readonly CoachSkillManager _coachSkillManager;
        public CoachSkillController(ICoachSkillService coachskill)
        {
            _coachSkillManager = (CoachSkillManager)coachskill;
        }

        // GET: api/CoachSkill
        [HttpGet, ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse GetAll() => new EntityHttpResponse(System.Net.HttpStatusCode.OK, _coachSkillManager.GetAll(), true);

        // GET: api/CoachSkill/5
        //[ApiAuthorizeAttribute(Roles = "A")]
        [HttpGet, Route("{id}"), ResponseType(typeof(string))]
        public EntityHttpResponse Get(int id)
        {
            return new EntityHttpResponse(System.Net.HttpStatusCode.OK, _coachSkillManager.Get(x => x.id == id), true);
        }

        // POST: api/CoachSkill/Create
        [EnableCors("AnotherPolicy")]
        [HttpPost, Route("{CoachSkill}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Create([FromBody] CoachSkill value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _coachSkillManager, true);
        }

        // PUT: api/CoachSkill/Update/5
        [HttpPut, Route("{CoachSkill}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Update([FromBody] CoachSkill value)
        {
            return ControlBeforeAddorUpdate(value, ModelState, Request, _coachSkillManager, false);
        }

        // DELETE: api/CoachSkill/Delete/5
        [HttpDelete, Route("{id}"), ResponseType(typeof(string))]
        //[ApiAuthorizeAttribute(Roles = "A")]
        public EntityHttpResponse Delete(int id)
        {
            _coachSkillManager.Delete(x => x.id == id);
            _coachSkillManager.Save();
            return new EntityHttpResponse(System.Net.HttpStatusCode.NoContent, null, true);
        }
    }
}