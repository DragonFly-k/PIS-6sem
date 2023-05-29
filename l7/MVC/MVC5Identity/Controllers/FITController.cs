using System.Web.Mvc;

namespace MvcIdentityLab.Controllers
{
    public class FITController : Controller
    {
        [Authorize] 
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FIT_IS()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FIT_PI()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FIT_ID()
        {
            return View();
        }
    }
}