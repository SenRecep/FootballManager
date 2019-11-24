using System.Web.Http.Controllers;


namespace FootballManager.Api.Authorize
{
    public class ApiAuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var ActionRoles = Roles;
            base.OnAuthorization(actionContext);
        }
    }
}
