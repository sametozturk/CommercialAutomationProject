﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomationProject.Models.Entities
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Explanation { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}