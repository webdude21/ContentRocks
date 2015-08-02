namespace Web
{
    using System.Web.Optimization;

    using Infrastructure.Constants;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);

            RegisterStyles(bundles);

            bundles.Add(new StyleBundle(ClientResources.Css).Include(ClientResources.BootstrapStylesPath, ClientResources.SiteCssPath));

            BundleTable.EnableOptimizations = false;
        }

        public static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(ClientResources.JQuery).Include(ClientResources.JQueryPath));

            bundles.Add(new ScriptBundle(ClientResources.JQueryValidation).Include(ClientResources.JQueryValidationPath));

            bundles.Add(new ScriptBundle(ClientResources.JQueryUnobtrusive).Include(ClientResources.JQueryUnobtrusivePath));

            bundles.Add(new ScriptBundle(ClientResources.Modernizr).Include(ClientResources.ModernizrPath));

            bundles.Add(new ScriptBundle(ClientResources.Bootstrap).Include(ClientResources.BootstrapPath, ClientResources.RespondPath));

            bundles.Add(new ScriptBundle(ClientResources.JQueryFileUpload).Include(ClientResources.JQueryUiPath, ClientResources.JQueryFileUploadPath));

            bundles.Add(new ScriptBundle(ClientResources.ZeroClipBoard).Include(ClientResources.ZeroClipBoardPath));

            bundles.Add(new ScriptBundle(ClientResources.CodeMirror).Include(ClientResources.CodeMirrorMainPath,
                     "~/Scripts/CodeMirror/mode/clike.js",
                     "~/Scripts/CodeMirror/mode/javascript.js"));
        }

        public static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle(ClientResources.Css).Include(ClientResources.BootstrapStylesPath, ClientResources.SiteCssPath));
            bundles.Add(new StyleBundle(ClientResources.CodeMirrorStyles).Include(ClientResources.CodeMirrorStylesPath,
                "~/Content/CodeMirror/theme/tomorrow-night-eighties.css",
                "~/Content/CodeMirror/theme/monokai.css"));
        }
    }
}