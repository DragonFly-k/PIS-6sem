using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace l4.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            ActionResult result;

            if (!Request.IsAjaxRequest())
                result = View(Request);
            else
                result = PartialView("_NotFound", Request);

            return result;
        }
    }
}