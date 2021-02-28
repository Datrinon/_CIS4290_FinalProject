using System.Web;
using System.Web.Optimization;

namespace QwiloMVCStore
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            // Qwilo project
            // CSS
            bundles.Add(new StyleBundle("~/bundles/qwilo/css").Include(
                      "~/Content/QwiloStore/css/favicon.ico",
                      "~/Content/QwiloStore/css/bootstrap.min.css",
                      "~/Content/QwiloStore/revolution/settings.css",
                      "~/Content/QwiloStore/css/style.css",
                      "~/Content/QwiloStore/css/responsive.css",
                      "~/Content/QwiloStore/css/custom.css"));
            // JavaScript
            bundles.Add(new ScriptBundle("~/bundles/qwilo/js").Include(
                    "~/Scripts/QwiloStore/js/jquery.min.js",
                    "~/Scripts/QwiloStore/js/popper.min.js",
                    "~/Scripts/QwiloStore/js/bootstrap.min.js",
                    "~/Scripts/QwiloStore/js/mega-menu/mega_menu.js",
                    "~/Scripts/QwiloStore/js/ionicons.js",
                    "~/Scripts/QwiloStore/js/main.js",
                    "~/Scripts/QwiloStore/revolution/js/jquery.themepunch.tools.min.js",
                    "~/Scripts/QwiloStore/revolution/js/jquery.themepunch.revolution.min.js",
                    "~/Scripts/QwiloStore/revolution/js/extensions/revolution.extension.actions.min.js",
                    "~/Scripts/QwiloStore/revolution/js/extensions/revolution.extension.carousel.min.js",
                    "~/Scripts/QwiloStore/revolution/js/extensions/revolution.extension.kenburn.min.js",
                    "~/Scripts/QwiloStore/revolution/js/extensions/revolution.extension.layeranimation.min.js",
                    "~/Scripts/QwiloStore/revolution/js/extensions/revolution.extension.migration.min.js",
                    "~/Scripts/QwiloStore/revolution/js/extensions/revolution.extension.navigation.min.js",
                    "~/Scripts/QwiloStore/revolution/js/extensions/revolution.extension.parallax.min.js",
                    "~/Scripts/QwiloStore/revolution/js/extensions/revolution.extension.slideanims.min.js",
                    "~/Scripts/QwiloStore/revolution/js/extensions/revolution.extension.video.min.js",
                    "~/Scripts/QwiloStore/js/custom.js"));
        }
    }
}
