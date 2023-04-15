using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.UI;

namespace b.Controllers
{
    public class CHResearchController : Controller
    {
        static DateTime date = DateTime.Now;

        [HttpGet]
        [OutputCache(Location = OutputCacheLocation.Any, Duration = 10)] // 5
        public ActionResult AD()
        {
            date = DateTime.Now;
            return Content($"{date}");
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.Any, Duration = 14, VaryByParam = "x,y")] // 7
        public ActionResult AP()
        {
            var x = Request.QueryString.Get("x");
            var y = Request.QueryString.Get("y");

            date = DateTime.Now;
            return Content($"{date}: {x} - {y}");
        }
    }
}