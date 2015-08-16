namespace Web.Infrastructure.Validators
{
    using System;
    using System.Web;
    using System.Web.Routing;

    using Data;

    using Models;
    using Models.Contracts;

    using Services;
    using Services.Contracts;

    public class FriendlyUrlValidator<TFriendlyUrl> : IRouteConstraint
        where TFriendlyUrl : BaseModel, IFriendlyUrl
    {
        private readonly IFriendlyUrlService<TFriendlyUrl> friendlyUrlService;

        public FriendlyUrlValidator(IFriendlyUrlService<TFriendlyUrl> friendlyUrlService)
        {
            this.friendlyUrlService = friendlyUrlService;
        }

        public FriendlyUrlValidator()
            : this(new FriendlyUrlService<TFriendlyUrl>(new UnitOfWork()))
        {
        }

        public bool Match(
            HttpContextBase httpContext,
            Route route,
            string friendlyUrl,
            RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            var paramValue = values[friendlyUrl] as String;
            return paramValue != null && this.friendlyUrlService.UrlExists(paramValue);
        }
    }
}