using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Showroom.Entities;
using Showroom.ExtentionMethods;

namespace Showroom.ActionFilters
{
    public class AuthenticationFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Session.Get<User>("loggedUser") == null)
                context.Result = new RedirectResult("/Home/Login");
        }
    }
}
