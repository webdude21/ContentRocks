namespace Web.Infrastructure.Filters
{
    using System.Net;
    using System.Web.Mvc;

    public class VerifyAjaxRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest, "This is only accessible trough an AJAX request");
            }

            base.OnActionExecuted(filterContext);
        }
    }
}