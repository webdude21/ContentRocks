namespace Web.Infrastructure.DataRetrievers
{
    using System.Web.Mvc;

    using Ninject;

    using Web.Infrastructure.Cache;

    public class PostsDataRetrieverAttribute : ActionFilterAttribute
    {
        [Inject]
        public ICacheService Cache { get; set; }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Posts = this.Cache.HomePosts;
            base.OnResultExecuting(filterContext);
        }
    }
}