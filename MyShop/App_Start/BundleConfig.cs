using System.Web;
using System.Web.Optimization;

namespace MyShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Moved bootstrap css to own style tag in the _layout page.  This is to remove it from the optimizations which was breaking the fonts and icons.
            bundles.Add(new StyleBundle("~/styles").IncludeDirectory("~/Assets", "*.css", true));


            bundles.Add(new ScriptBundle("~/vendors").Include(
                        "~/Assets/Vendors/jquery-3.1.1.min.js",
                        "~/Assets/Vendors/bootstrap.min.js",
                        "~/Assets/Vendors/toastr.min.js",
                        "~/Assets/Vendors/angular.min.js",
                        "~/Assets/Vendors/angular-route.min.js",
                        "~/Assets/Vendors/angular-cookies.min.js",
                        "~/Assets/Vendors/lodash.core.min.js",
                        "~/Assets/Vendors/loading-bar.js"));

            bundles.Add(new ScriptBundle("~/app").IncludeDirectory("~/Assets/app", "*.js", true));

            bundles.Add(new ScriptBundle("~/misc").IncludeDirectory("~/Assets/misc", "*.js", true));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //    "~/Content/css/site.css",
            //    "~/Content/css/bootstrap.css",
            //    "~/Content/css/bootstrap-theme.css",
            //    "~/Content/css/font-awesome.css",
            //    "~/Content/css/morris.css",
            //    "~/Content/css/toastr.css",
            //    "~/Content/css/jquery.fancybox.css",
            //    "~/Content/css/loading-bar.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
