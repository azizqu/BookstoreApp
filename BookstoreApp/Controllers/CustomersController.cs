using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookstoreApp.Models;
using BookstoreApp.Models.Database;

namespace BookstoreApp.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers/Details
        public ActionResult Details(int id) //have to call it id due to routeconfig
        {
            //todo: get customer from the database
            return Content("Details of "+id);
        }
        public ActionResult CustomerList()
        {
            CustomerDAO.GetCustomerList();
            
            return View();
        }

        public ActionResult CustomerForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //validation
            if (!ModelState.IsValid)
                return View("CustomerForm", customer);



            CustomerDAO.Create(customer);

            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            //todo: load customer from DB using id
            var customer = new Customer
            {
                Id = id,
                Name = "Test Customer",
                BirthDate = new DateTime(2000, 01, 01),
                IsSubscriber = false,
                Email = "test@yahoo.com"
            };
            return View("CustomerForm", customer);
        }

        public ActionResult Index()
        {
           
            return View();
        }
    }
}