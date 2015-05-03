namespace Web
{
    using System.Web.Optimization;

    using Web.Infrastructure.Constants;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(ClientResources.JQuery).Include(ClientResources.JQueryPath));

            bundles.Add(new ScriptBundle(ClientResources.JQueryValidation).Include(ClientResources.JQueryValidationPath));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle(ClientResources.Modernizr).Include(ClientResources.ModernizrPath));

            bundles.Add(new ScriptBundle(ClientResources.Bootstrap).Include(ClientResources.BootstrapPath, ClientResources.RespondPath));

            bundles.Add(new StyleBundle(ClientResources.Css).Include(ClientResources.BootstrapStylesPath, ClientResources.SiteCssPath));
        }
    }
}