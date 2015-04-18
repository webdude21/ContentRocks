namespace Web.Infrastructure.Constants
{
    public static class DefaultRoute
    {
        public const string DefaultAction = Actions.Index;

        public const string DefaultController = Controllers.HomeController;

        public const string Name = "Default";

        public const string UrlPattern = "{controller}/{action}/{id}";
    }
}