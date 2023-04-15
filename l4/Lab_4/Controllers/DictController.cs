using Lab_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_4.Controllers
{
    public class DictController : Controller
    {
        // GET: Dict
        DirectoryRepository DirectoryRepository = new DirectoryRepository();

        public ActionResult Index()
        {
            ViewBag.data = DirectoryRepository.GetDirectoryList();
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddSave(string last_name, string phone_number)
        {
            Directory directory = new Directory
            {
                phone_number = phone_number,
                last_name = last_name
            };
            DirectoryRepository.Create(directory);

            if (!DirectoryRepository.Save()) return new HttpStatusCodeResult(400);
            return Redirect("/Dict/index");
        }
        public ActionResult Update(string last_name, string phone_number)
        {
            ViewBag.last_name = last_name;
            ViewBag.phone_number = phone_number;

            return View();
        }
        public ActionResult UpdateSave(string last_name, string phone_number)
        {
            Directory directory = new Directory
            {
                phone_number = phone_number,
                last_name = last_name
            };
            DirectoryRepository.Update(directory);
            if (!DirectoryRepository.Save()) return new HttpStatusCodeResult(400);
            return Redirect("/Dict/index");
        }
        public ActionResult Delete(string last_name, string phone_number, int id)
        {
            ViewBag.last_name = last_name;
            ViewBag.phone_number = phone_number;
            ViewBag.id = id;
            return View();
        }
        public ActionResult DeleteSave(string last_name, string phone_number)
        {
            Directory directory = new Directory
            {
                phone_number = phone_number,
                last_name = last_name
            };
            DirectoryRepository.Delete(directory);
            if (!DirectoryRepository.Save()) return new HttpStatusCodeResult(400);
            return Redirect("/Dict/index");
        }
    }
}