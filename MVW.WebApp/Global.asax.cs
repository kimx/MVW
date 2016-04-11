using MVW.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVW.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static MVWJsonDataBase jsonDb;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MvcHandler.DisableMvcResponseHeader = true;

            string folder = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
            jsonDb = new MVWJsonDataBase(folder);

            //jsonDb.Word.AddRange(new MVWDataBase().Word.ToArray());
            //jsonDb.SaveChanges();

        }
    }
}
