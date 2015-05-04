namespace Web.Controllers
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;

    using Web.Infrastructure;

    public abstract class BaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName;

            var cultureCookie = this.Request.Cookies["_culture"];

            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                cultureName = this.Request.UserLanguages != null && this.Request.UserLanguages.Length > 0
                                  ? this.Request.UserLanguages[0]
                                  : null;
            }

            cultureName = CultureHelper.GetImplementedCulture(cultureName);

            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            return base.BeginExecuteCore(callback, state);
        }

        protected void ClearCache()
        {
            foreach (DictionaryEntry entry in this.HttpContext.Cache)
            {
                this.HttpContext.Cache.Remove((string)entry.Key);
            }
        }
    }
}