using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStoreMVC.ViewModels
{
    public class CreateTransaction
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public IEnumerable<int> ProductIds { get; set; } = new List<int>();
    }
}