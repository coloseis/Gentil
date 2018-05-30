using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Gentil.WebAPI.Autorize
{
    public class TokenFilter : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (!EsAllowAnonymous(actionContext) && !EsTokenValido(actionContext))
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Unauthorized");

            if (!Roles.Contains(AutorizeHelper.Principal.Role))
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Forbidden");
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (!EsAllowAnonymous(actionContext) && !EsTokenValido(actionContext))
                return false;

            return Roles == "" || Roles.Contains(AutorizeHelper.Principal.Role);
        }

        private static bool EsAllowAnonymous(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }

        private static bool EsTokenValido(HttpActionContext actionContext)
        {
            IEnumerable<string> token = null;
            if (!actionContext.Request.Headers.TryGetValues("X-XSRF-TOKEN", out token))
            {
                return false;
            }

            (new JsonWebToken()).DecodeToPrincipal(token.Single());

            if (AutorizeHelper.Principal.Identity.IsAuthenticated)
            {
                log4net.GlobalContext.Properties["user_name"] = AutorizeHelper.Principal.Identity.Name;
                return true;
            }

            throw new HttpResponseException(actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Error al autorizar."));
        }
    }
}