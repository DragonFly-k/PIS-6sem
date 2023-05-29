using System.Web.Mvc;

namespace MvcIdentityLab.Controllers
{
    public class BSTUController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Config()
        {
            return View(); 
        }
    }
}