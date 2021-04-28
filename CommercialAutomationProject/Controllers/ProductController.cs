using CommercialAutomationProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomationProject.Controllers
{
    public class ProductController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            var products=db.Products.Where(x=>x.Status==true).ToList();
            return View(products);
        }

        public ActionResult Add()
        {
            List<SelectListItem> categoryList = (from x in db.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.category = categoryList;
                                               
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var delete = db.Products.Find(id);
            db.Products.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> categoryList = (from x in db.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.category = categoryList;
            var product = db.Products.Find(id);
            return View("Update", product);
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {

            var guncelle = db.Products.Find(product.ProductId);
            guncelle.ProductName = product.ProductName;
            guncelle.Brand = product.Brand;
            guncelle.Stock = product.Stock;
            guncelle.Purchaseprice = product.Purchaseprice;
            guncelle.SalePrice = product.SalePrice;
            guncelle.ProductImage = product.ProductImage;
            guncelle.Status = product.Status;
            guncelle.CategoryId = product.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}