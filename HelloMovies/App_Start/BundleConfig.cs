using System.Web;
using System.Web.Optimization;

namespace HelloMovies
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/external").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/angular-messages.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").IncludeDirectory(
                        "~/App",
                        "*.js", true));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));  

            // bootstrap-main gets generated from external gulp process
            bundles.Add(new StyleBundle("~/content/css").Include(
                      "~/Content/css/bootstrap-main.css",
                      "~/Content/css/site.css"));
        }
    }
}
