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
            var degerler = db.CurrentAccounts.Where(x=>x.Status==true).ToList();
            return View(degerler);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(CurrentAccount current)
        {
            current.Status = true;
            db.CurrentAccounts.Add(current);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var delete = db.CurrentAccounts.Find(id);
            delete.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var current = db.CurrentAccounts.Find(id);
            return View("Update", current);
        }
        [HttpPost]
        public ActionResult Update(CurrentAccount current)
        {
            if(!ModelState.IsValid)
            {
                return View("Update")
            }
            var guncelle = db.CurrentAccounts.Find(current.CurrentId);
            guncelle.CurrentName = current.CurrentName;
            guncelle.CurrentSurname = current.CurrentSurname;
            guncelle.CurrentCity = current.CurrentCity;
            guncelle.CurrentEmail = current.CurrentEmail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerSale(int id)
        {
            var deger = db.SaleMovements.Where(x => x.CurrentAccountId == id).ToList();
            var cari = db.CurrentAccounts.Where(x => x.CurrentId == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.current = cari;
            return View(deger);
        }
    }
}