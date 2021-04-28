using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomationProject.Models.Entities;

namespace CommercialAutomationProject.Controllers
{
    public class CategoryController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            var deger = db.Categories.ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            db.Categories.Add(category);
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
            var category = db.Categories.Find(id);
            return View("Guncelle",category);
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            var guncelle = db.Categories.Find(category.CategoryId);
            guncelle.CategoryName = category.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}