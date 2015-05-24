namespace Web.Infrastructure.Validators
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Routing;

    using Data;
    using Data.Contracts;

    using Models.Contracts;

    public class FriendlyUrlValidator<TFriendlyUrl> : IRouteConstraint where TFriendlyUrl : class, IFriendlyUrl
    {
        private readonly IUnitOfWork unitOfWork;

        public FriendlyUrlValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public FriendlyUrlValidator()
            : this(new UnitOfWork())
        {
            
        }

        public bool Match(HttpContextBase httpContext, Route route, string friendlyUrl, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var paramValue = values[friendlyUrl] as String;
            return paramValue != null && this.unitOfWork.Set<TFriendlyUrl>().Any(page => page.FriendlyUrl == paramValue);
        }
    }
}