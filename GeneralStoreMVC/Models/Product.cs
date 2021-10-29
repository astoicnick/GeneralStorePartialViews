using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStoreMVC.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        [Display(Name = "Inventory Count")]
        public int InventoryCount { get; set; }
        //public virtual ICollection<Transaction> Transactions { get; set; }
    }
}