using System.Web;
using System.Web.Optimization;

namespace WebDocTruyenOnline
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jscore").Include(
                        "~/Scripts/jquery-1.10.2.min.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Content/Client/LayoutJs/custom.js",
                        "~/Content/Client/LayoutJs/cookie.js",
                        "~/Content/Client/LayoutJs/common.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/controller").Include(
                        "~/Common/BaseJs.js",
                        "~/Content/Client/LayoutJs/wp-embed.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/core").Include(
                      "~/Content/Client/LayoutCss/autosearch.css",
                      "~/Content/Client/LayoutCss/pagenavi-css.css",
                      "~/Content/Client/LayoutCss/thanhvien.css",
                      "~/Content/Client/LayoutCss/category-css.css",
                      "~/Content/Client/LayoutCss/theme.min.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/Client/font-awesome-4.7.0/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Content/Client/LayoutCss/manga=css.css",
                      "~/Content/Client/LayoutCss/manga-common.css",
                      "~/Content/Client/LayoutCss/manga-post.css"
                      ));
        }
    }
}
