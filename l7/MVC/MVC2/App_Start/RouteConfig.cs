﻿using System.Web.Mvc;
using System.Web.Routing;

namespace MVC2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Dict", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}