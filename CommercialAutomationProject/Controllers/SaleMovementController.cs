using CommercialAutomationProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomationProject.Controllers
{
    public class SaleMovementController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            var deger = db.SaleMovements.ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            List<SelectListItem> urun = (from x in db.Products.ToList()
                                                 select new SelectListItem { Value = x.ProductId.ToString(), Text = x.ProductName }).ToList();
            ViewBag.products = urun;

            List<SelectListItem> cari = (from x in db.CurrentAccounts.ToList()
                                         select new SelectListItem { Value = x.CurrentId.ToString(), Text = x.CurrentName }).ToList();
            ViewBag.current = cari;

            List<SelectListItem> personel = (from x in db.Employees.ToList()
                                         select new SelectListItem { Value = x.EmployeeId.ToString(), Text = x.EmployeeName }).ToList();
            ViewBag.employee = personel; 
            return View();
        }
        [HttpPost]
        public ActionResult Add(SaleMovement saleMovement)
        {
            saleMovement.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.SaleMovements.Add(saleMovement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> urun = (from x in db.Products.ToList()
                                         select new SelectListItem { Value = x.ProductId.ToString(), Text = x.ProductName }).ToList();
            ViewBag.products = urun;

            List<SelectListItem> cari = (from x in db.CurrentAccounts.ToList()
                                         select new SelectListItem { Value = x.CurrentId.ToString(), Text = x.CurrentName }).ToList();
            ViewBag.current = cari;

            List<SelectListItem> personel = (from x in db.Employees.ToList()
                                             select new SelectListItem { Value = x.EmployeeId.ToString(), Text = x.EmployeeName }).ToList();
            ViewBag.employee = personel;
            var sale = db.SaleMovements.Find(id);
            return View("Guncelle", sale);
        }
        [HttpPost]
        public ActionResult Update(SaleMovement saleMovement)
        {
            var guncelle = db.SaleMovements.Find(saleMovement.SaleId);
            guncelle.CurrentAccountId = saleMovement.CurrentAccountId;
            guncelle.Number = saleMovement.Number;
            guncelle.Price = saleMovement.Price;
            guncelle.EmployeeId = saleMovement.EmployeeId;
            guncelle.Date = saleMovement.Date;
            guncelle.TotalAmount = saleMovement.TotalAmount;
            guncelle.ProductId = saleMovement.ProductId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SaleDetail(int id)
        {
            var degerler = db.SaleMovements.Where(x => x.SaleId == id).ToList();
            return View(degerler);
        }
    }
}