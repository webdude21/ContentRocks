namespace Web.Infrastructure.ActionResults
{
    using System.Net;
    using System.Web.Mvc;

    public class HttpStatusCodeViewResult : ViewResult
    {
        private readonly string description;

        private readonly HttpStatusCode statusCode;

        public HttpStatusCodeViewResult(HttpStatusCode statusCode, string description = null)
            : this(null, statusCode, description)
        {
        }

        public HttpStatusCodeViewResult(string viewName, HttpStatusCode statusCode, string description = null)
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