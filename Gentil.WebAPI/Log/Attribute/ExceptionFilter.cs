using System.Web.Http.Filters;
using log4net;

namespace Gentil.WebAPI.Log.Attribute
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        protected static readonly ILog Log = LogManager.GetLogger("GentilLogger");

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Log.Error(actionExecutedContext.Exception.Message, actionExecutedContext.Exception);
            base.OnException(actionExecutedContext);
        }
    }
}