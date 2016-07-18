using System.Web;
using System.Web.Optimization;

namespace RentACar
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scriptsRu").Include(
                        
                       "~/Scripts/script_ru.js",
                       "~/Scripts/jquery-ui.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/scriptsEn").Include(
                
                       "~/Scripts/script.js",
                        "~/Scripts/jquery-ui.min.js"
                       ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/jquery-ui.min.css",
                      "~/Content/style.css"));
            bundles.Add(new StyleBundle("~/Content/cssAdmin").Include(
                "~/Content/jquery-ui.min.css",
                      "~/Content/styleAdmin.css"));
        }
    }
}
