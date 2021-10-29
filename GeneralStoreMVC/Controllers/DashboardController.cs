using GeneralStoreMVC.Services;
using GeneralStoreMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStoreMVC.Controllers
{
    public class DashboardController : Controller
    {
        // IProductService
        // ICustomerService

        // GET: Dashboard
        public ActionResult Index()
        {
            var productSvc = new ProductService();
            var customerSvc = new CustomerService();
            var transactionSvc = new TransactionService();
            var model = new DashboardViewModel();
            model.LowestStockedProducts = productSvc.LowestStockedProducts();
            model.TopCustomers = customerSvc.TopCustomers();
            model.MostRecentTransactions = transactionSvc.MostRecentTransactions();

            return View(model);
        }
    }
}