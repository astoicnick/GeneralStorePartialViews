using GeneralStoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeneralStoreMVC.Services
{
    public class TransactionService
    {
        public IEnumerable<Transaction> MostRecentTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Transactions.Include("Customer").Include("Products").OrderByDescending(t => t.CreatedAt);
                return query.ToArray();
            }
        }
    }
    public class ProductService
    {
        public IEnumerable<Product> LowestStockedProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.OrderBy(p => p.InventoryCount);
                return query.ToArray();
            }
        }
    }
    public class CustomerService
    {
        public IEnumerable<Customer> TopCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Customers.Include("Transactions").OrderByDescending(c => c.Transactions.Count);
                return query.ToArray();
            }
        }
    }
}