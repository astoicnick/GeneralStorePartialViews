using GeneralStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneralStoreMVC.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Customer> TopCustomers { get; set; }
        public IEnumerable<Product> LowestStockedProducts { get; set; }
        public IEnumerable<Transaction> MostRecentTransactions { get; set; }
    }
}