using System.Web.Mvc;

namespace MvcIdentityLab.Controllers
{
    public class FIEController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Employer")] 
        public ActionResult FIE_TM()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FIE_UR()
        {
            return View();
        }

        [Authorize(Roles = "Employer")]
        public ActionResult FIE_UP()
        {
            return View();
        }
    }
}