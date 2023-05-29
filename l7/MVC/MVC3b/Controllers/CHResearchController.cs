using System;
using System.Globalization;
using System.Web.Mvc;

namespace Lab4b.Controllers
{
    [RoutePrefix("cached")]
    public class ChResearchController : Controller
    {
        [HttpGet]
        [Route("ad")]
        [OutputCache(Duration = 5)]
        public ActionResult Ad()
        {
            var time = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            return Content(time + "Response result");
        }

        [HttpPost]
        [Route("ap")]
        [OutputCache(Duration = 50, VaryByParam = "x;y")]
        public ActionResult Ap()
        {
            var x = Request.QueryString.Get("x");
            var y = Request.QueryString.Get("y");

            return Content($"{DateTime.Now}: {x} - {y}");
        }
    }
}