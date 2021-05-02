using CommercialAutomationProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommercialAutomationProject.Controllers
{
    public class InvoiceController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            var fatura = db.Invoices.ToList();
            return View(fatura);
        }
        public ActionResult Add()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult Add(Invoice invoice)
        {
            db.Invoices.Add(invoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var invoice = db.Invoices.Find(id);
            return View("Update", invoice);
        }
        [HttpPost]
        public ActionResult Update(Invoice invoice)
        {

            var guncelle = db.Invoices.Find(invoice.InvoiceId);
            guncelle.invoiceSerial = invoice.invoiceSerial;
            guncelle.InvoiceNumber = invoice.InvoiceNumber;
            guncelle.TaxAdministration = invoice.TaxAdministration;
            guncelle.Date = invoice.Date;
            guncelle.Time = invoice.Time;
            guncelle.Deliverer = invoice.Deliverer;
            guncelle.Recipient = invoice.Recipient;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InvoiceDetail(int id)
        {
            var deger = db.InvoiceDetails.Where(x => x.InvoiceId == id).ToList();
            return View(deger);
        }
        public ActionResult NewInvoiceDetail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            db.InvoiceDetails.Add(invoiceDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}