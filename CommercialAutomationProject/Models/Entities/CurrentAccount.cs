using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomationProject.Models.Entities
{
    public class CurrentAccount
    {
        [Key]
        public int CurrentId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter girilebilir.")]
        [Required(ErrorMessage ="Bu alan boş geçilemez.")]
        public string CurrentName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girilebilir.")]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string CurrentSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CurrentCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girilebilir.")]
        public string CurrentEmail { get; set; }
        public bool Status { get; set; } 

        public ICollection<SaleMovement> SaleMovements { get; set; }
    }
}