﻿namespace Web
{
    using System.Web.Optimization;

    using Web.Infrastructure.Constants;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(ClientResources.JQuery).Include(ClientResources.JQueryPath));

            bundles.Add(new ScriptBundle(ClientResources.JQueryValidation).Include(ClientResources.JQueryValidationPath));

            bundles.Add(new ScriptBundle(ClientResources.Modernizr).Include(ClientResources.ModernizrPath));

            bundles.Add(new ScriptBundle(ClientResources.Bootstrap).Include(ClientResources.BootstrapPath, ClientResources.RespondPath));

            bundles.Add(new StyleBundle(ClientResources.Css).Include(ClientResources.BootstrapStylesPath, ClientResources.SiteCssPath));
        }
    }
}