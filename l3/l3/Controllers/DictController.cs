using l3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace l3.Controllers
{
    public class DictController : Controller
    {
        DictObjectContext db = new DictObjectContext();
        public ActionResult Index()
        {
            IEnumerable<DictObj> dictObjects = db.GetAll().OrderBy(i => i.FIO);
            ViewBag.Objects = dictObjects;
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewBag.Object = db.Find(id);
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(DictObj dict)
        {
            try
            {
                db.Add(dict);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Object = db.Find(id);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSave(DictObj dict)
        {
            try
            {
                db.Update(dict);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.Object = db.Find(id);
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSave(DictObj dict)
        {
            try
            {
                db.Delete(dict.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            ViewBag.Method = Request.HttpMethod;
            ViewBag.URL2 = Request.Url.ToString().Split(';')[1];
            return View();
        }
    }
}