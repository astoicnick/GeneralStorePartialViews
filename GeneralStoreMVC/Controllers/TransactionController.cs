using GeneralStoreMVC.Models;
using GeneralStoreMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GeneralStoreMVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Transaction
        public ActionResult Index()
        {
            var transactions = _db.Transactions.Include(t => t.Customer).Include(t => t.Products).ToList();
            return View("Index", transactions);
        }

        // GET: Transaction/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(_db.Customers, "CustomerID", "FullName");
            ViewBag.Products = new SelectList(_db.Products, "ProductID", "Name");
            return View();
        }

        // POST: Transaction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTransaction model)
        {
            if (ModelState.IsValid)
            {
                var transaction = new Transaction();
                transaction.Products = new List<Product>();
                var customer = _db.Customers.Find(model.CustomerId);
                if (customer != null)
                {
                    transaction.CustomerID = customer.CustomerID;
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                foreach (int productId in model.ProductIds)
                {
                    var product = _db.Products.Find(productId);
                    if (product != null)
                    {
                        if (product.InventoryCount < 1)
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }
                        transaction.Products.Add(product);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                transaction.CreatedAt = DateTime.Now;
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(_db.Customers, "CustomerID", "FullName", model.CustomerId);
            ViewBag.Products = new SelectList(_db.Products, "ProductID", "Name", model.ProductIds);

            return View(model);
        }
    }
}