using System.Web.Mvc;
using System.Web.Routing;

namespace Lab4a
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                "C01",
                "CResearch/{action}",
                new { controller = "CResearch", action = "C01" }
            );

            routes.MapRoute(
                "M03",
                "V3/{controller}/{id}/{action}",
                new { controller = "MResearch", action = "M03", id = UrlParameter.Optional },
                new { id = @"X?" }
            );

            routes.MapRoute(
                "M02",
                "V2/{controller}/{action}",
                new { controller = "MResearch", action = "M02" },
                new { action = "M01|M02" }
            );

            routes.MapRoute(
                "M01",
                "{controller}/{action}/{id}",
                new { controller = "MResearch", action = "M01", id = UrlParameter.Optional },
                new { id = @"1?", action = "(M01|M02)" }
            );

            routes.MapRoute(
                "Error",
                "{*catchall}",
                new { controller = "MResearch", action = "MXX" },
                new { controller = "MResearch", action = "MXX" }
            );
        }
    }
}