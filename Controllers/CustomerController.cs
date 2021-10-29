using System.Linq;
using GeneralStoreMVC.Data;
using GeneralStoreMVC.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace GeneralStoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly GeneralStoreDbContext _ctx;

        public CustomerController(GeneralStoreDbContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            var customers =  _ctx.Customers.Select(customer => new CustomerIndexModel
            {
                ID = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            });
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerCreateModel model)
        {
            _ctx.Customers.Add(new Customer 
            {
                Name = model.Name,
                Email = model.Email
            });
            if (_ctx.SaveChanges() == 1)
            {
                return Redirect("/customer");   
            }
        }
    }
}
