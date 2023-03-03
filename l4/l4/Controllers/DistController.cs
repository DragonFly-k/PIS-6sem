using l4.Db;
using l4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace l4.Controllers
{
    public class DistController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Contact> contacts = ReadPhoneBook();
            ViewBag.Contacts = contacts;
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSave(Contact contact)
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
            }
            return Redirect("/Dist/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(FindById(id));
        }

        [HttpPost]
        public ActionResult DeleteSave(Contact contact)
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                db.Contacts.Attach(contact);
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
            return Redirect("/Dist/Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(FindById(id));
        }

        [HttpPost]
        public ActionResult UpdateSave(Contact contact)
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                db.Contacts.Attach(contact);
                db.Entry(contact)
                    .Property(c => c.PhoneNumber).IsModified = true;
                db.Entry(contact)
                    .Property(c => c.Name).IsModified = true;
                db.SaveChanges();
            }

            return Redirect("/Dist/Index");
        }

        private List<Contact> ReadPhoneBook()
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                List<Contact> contacts = db.Contacts.ToList();
                return contacts.OrderBy(c => c.Name).ToList();
            }
        }

        private Contact FindById(long id)
        {
            using (PhoneBookContext db = new PhoneBookContext())
            {
                return db.Contacts.Find(id);
            }
        }
    }
}