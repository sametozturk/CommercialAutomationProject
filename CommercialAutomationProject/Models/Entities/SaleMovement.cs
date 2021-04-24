using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommercialAutomationProject.Models.Entities
{
    public class SaleMovement
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }

        public Product Product { get; set; }
        public CurrentAccount CurrentAccount { get; set; }
        public Employee Employee { get; set; }
    }
}