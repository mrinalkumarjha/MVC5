﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HelloWorld
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // It is collection of route which wont be served 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.config");


            routes.MapRoute(
                name: "Home",
                url: "Home",
                defaults: new { controller = "Home", action = "GoToHome", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home1",
                url: "Home/Home",
                defaults: new { controller = "Home", action = "GoToHome", id = UrlParameter.Optional }
            );

           // routes.MapRoute(
           //    name: "Home2",
           //    url: "",
           //    defaults: new { controller = "Home", action = "GoToHome", id = UrlParameter.Optional }
           //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
