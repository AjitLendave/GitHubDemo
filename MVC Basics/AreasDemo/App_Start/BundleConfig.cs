using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace AreasDemo.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {    //Javascript/Jquery bundle
            bundles.Add(new ScriptBundle("~/bundles/MyJsBundles").Include(
                         "~/Scripts/JavaScript1.js",
                         "~/Scripts/JavaScript2.js",
                         "~/Scripts/JavaScript3.js"));

            //Css bundel
            // bundles.Add(new StyleBundle("").Include(
                      // ));

            // Code removed for clarity.
            BundleTable.EnableOptimizations = true;
        }
    }
}