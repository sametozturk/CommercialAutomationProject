using CommercialAutomationProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomationProject.Controllers
{
    public class CurrentAccountController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            var degerler = db.CurrentAccounts.ToList();
            return View(degerler);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(CurrentAccount current)
        {
            db.CurrentAccounts.Add(current);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}