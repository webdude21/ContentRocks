namespace Web.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult PageNotFound()
        {
            this.Response.StatusCode = 404;
            return this.View();
        }
    }
}