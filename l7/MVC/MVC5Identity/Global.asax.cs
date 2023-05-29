using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcIdentityLab.Models;

namespace MvcIdentityLab
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        { 
            Database.SetInitializer(new AppDbInitializer());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}