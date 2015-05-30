namespace Web.Infrastructure.Filters
{
    using System;
    using System.Net;
    using System.Web.Mvc;

    using Web.Infrastructure.ActionResults;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NullModelCheckAttribute : ActionFilterAttribute
    {
        public NullModelCheckAttribute(string description = null)
        {
            this.Description = description;
            this.ViewName = "Error";
            this.StatusCode = HttpStatusCode.NotFound;
        }

        public string Description { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ViewName { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result as ViewResultBase;

            if (result != null && result.Model == null)
            {
                if (result is PartialViewResult)
                {
                    filterContext.Result = new HttpStatusCodePartialViewResult(
                        this.ViewName,
                        HttpStatusCode.NotFound,
                        this.Description);
                }
                else
                {
                    filterContext.Result = new HttpStatusCodeViewResult(
                        this.ViewName,
                        this.StatusCode,
                        this.Description);
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}