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
    public class TokenFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (EsAllowAnonymous(actionContext) || EsTokenValido(actionContext))
                return;

            throw new HttpResponseException(actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "No autorizado."));
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