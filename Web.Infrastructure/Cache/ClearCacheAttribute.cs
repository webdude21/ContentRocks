namespace Web.Infrastructure.Cache
{
    using System.Collections;
    using System.Web.Mvc;

    public class ClearInMemoryCache : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            foreach (DictionaryEntry entry in filterContext.HttpContext.Cache)
            {
                filterContext.HttpContext.Cache.Remove((string)entry.Key);
            }
            base.OnResultExecuting(filterContext);
        }
    }
}