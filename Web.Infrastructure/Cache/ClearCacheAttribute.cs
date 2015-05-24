namespace Web.Infrastructure.Cache
{
    using System;
    using System.Collections;
    using System.Web;
    using System.Web.Mvc;

    public class ClearCacheAfterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            ClearOutputCache(filterContext);
            ClearInMemoryCache(filterContext);
            base.OnResultExecuting(filterContext);
        }

        private static void ClearOutputCache(ControllerContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
        }

        private static void ClearInMemoryCache(ControllerContext filterContext)
        {
            foreach (DictionaryEntry entry in filterContext.HttpContext.Cache)
            {
                filterContext.HttpContext.Cache.Remove((string)entry.Key);
            }
        }
    }
}