using System.Net;
using System.Web.Mvc;

namespace Web.Infrastructure.ActionResults
{
    public class HttpStatusCodePartialViewResult : PartialViewResult
    {
        private readonly string description;

        private readonly HttpStatusCode statusCode;

        public HttpStatusCodePartialViewResult(HttpStatusCode statusCode, string description = null)
            : this(null, statusCode, description)
        {
        }

        public HttpStatusCodePartialViewResult(string viewName, HttpStatusCode statusCode, string description = null)
        {
            this.statusCode = statusCode;
            this.description = description;
            this.ViewName = viewName;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var httpContext = context.HttpContext;
            var response = httpContext.Response;

            response.TrySkipIisCustomErrors = true;
            response.StatusCode = (int)this.statusCode;
            response.StatusDescription = this.description;

            base.ExecuteResult(context);
        }
    }
}