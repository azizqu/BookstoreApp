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
            //load customer from DB
            var customers = CustomerDAO.GetCustomerList();
            
            return View(customers);
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

            var customerId = int.Parse(Request["customerId"]);
            customer.Id = customerId;

            if(customer.Id ==0 )
                CustomerDAO.Create(customer);
            else
            {
                CustomerDAO.Update(customer);
            }
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {
            //todo: load customer from DB using id
            var customer = CustomerDAO.GetCustomer(id);
            if (customer == null)
                return HttpNotFound();

            return View("CustomerForm", customer);
        }
        public ActionResult Delete(int id)
        {
            var customer = CustomerDAO.GetCustomer(id);
            if (customer == null)
                return HttpNotFound();
            CustomerDAO.Delete(customer);
            return RedirectToAction("CustomerList");
        }

        public ActionResult Index()
        {
           
            return View();
        }
    }
}