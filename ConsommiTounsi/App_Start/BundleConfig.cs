using System.Web;
using System.Web.Optimization;

namespace ConsommiTounsi
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            
            bundles.Add(new ScriptBundle("~/bundles/UserScripts").Include("~/Scripts/UserScripts/*.js"));
            bundles.Add(new StyleBundle("~/bundles/UserStyles").Include("~/Content/UserStyles/*.css", new CssRewriteUrlTransform()));

            BundleTable.EnableOptimizations = true;
        }
    }
}
