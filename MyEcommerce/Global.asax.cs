﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyEcommerce
{
    public class MvcApplication : System.Web.HttpApplication
    {

        private static string connString = ConfigurationManager.ConnectionStrings["MyEcomConStr"].ToString();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Start SqlDependency with application initialization
            SqlDependency.Start(connString);
        }

        protected void Application_End()
        {
            //Stop SQL dependency
            SqlDependency.Stop(connString);
        }
    }
}
