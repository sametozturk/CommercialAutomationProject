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

        public int ProductId { get; set; }
        public int CurrentAccountId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Product Product { get; set; }
        public virtual CurrentAccount CurrentAccount { get; set; }
        public virtual Employee Employee { get; set; }
    }
}