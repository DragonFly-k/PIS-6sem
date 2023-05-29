using System.Web.Mvc;
using System.Web.Routing;

namespace MVC1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Dict", action = "Index", id = UrlParameter.Optional },
                new { controller = "Dict", action = "Index|Add|AddSave|Update|UpdateSave|Delete|DeleteSave|Error" }
            );

            routes.MapRoute(
                "404-catch-all",
                "{*catchall}",
                new { controller = "Error", action = "NotFound" }
            );
        }
    }
}