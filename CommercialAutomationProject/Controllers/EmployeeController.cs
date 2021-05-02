using CommercialAutomationProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomationProject.Controllers
{
    public class EmployeeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            var employee = db.Employees.ToList();
            return View(employee);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> list = (from x in db.Departments.ToList()
                                         select new SelectListItem { Text = x.DepartmentName, Value = x.DepartmentId.ToString() }).ToList();
            ViewBag.department = list;
            var employee = db.Employees.Find(id);
            return View("Guncelle", employee);
        }
        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            var guncelle = db.Employees.Find(employee.EmployeeId);
            guncelle.EmployeeName = employee.EmployeeName;
            guncelle.EmployeeSurname = employee.EmployeeSurname;
            guncelle.EmployeeImage = employee.EmployeeImage;
            guncelle.DepartmentId = employee.DepartmentId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}