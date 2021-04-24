using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomationProject.Models.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public char invoiceSerial { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaxAdministration { get; set; }
        public DateTime Time { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Recipient { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Deliverer { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}