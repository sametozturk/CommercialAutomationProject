using CommercialAutomationProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomationProject.Controllers
{
    public class DepartmentController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            var departments = db.Departments.ToList();
            return View(departments);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var delete = db.Departments.Find(id);
            delete.Status=false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var department = db.Departments.Find(id);
            return View("Update", department);
        }
        [HttpPost]
        public ActionResult Update(Department department)
        {

            var guncelle = db.Departments.Find(department.DepartmentId);
            guncelle.DepartmentName = department.DepartmentName;               
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmentDetail(int id)
        {
            var degerler = db.Employees.Where(x => x.DepartmentId == id).ToList();
            var dashboard = db.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.department = dashboard;
            return View(degerler);
        }
        public ActionResult DepartmentSaleEmployee(int id)
        {
            var degerler = db.SaleMovements.Where(x => x.EmployeeId == id).ToList();
            var personel = db.Employees.Where(x => x.EmployeeId == id).Select(y => y.EmployeeName +" "+ y.EmployeeSurname).FirstOrDefault();
            ViewBag.employee = personel;
            return View(degerler);
        }
    }
}