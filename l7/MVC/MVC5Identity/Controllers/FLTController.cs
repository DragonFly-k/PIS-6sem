using System.Web.Mvc;

namespace MvcIdentityLab.Controllers
{
    public class FLTController : Controller
    {
        [Authorize] 
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FLT_LV()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FLT_LU()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FLT_LZ()
        {
            return View();
        }
    }
}