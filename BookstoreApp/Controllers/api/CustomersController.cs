using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using BookstoreApp.Models;
using BookstoreApp.Models.Database;

namespace BookstoreApp.Controllers.api
{
    public class CustomersController : ApiController
    {
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {

            return CustomerDAO.GetCustomerList();
        }
        [HttpPost]
        public Customer Create(Customer customer)
        {
            CustomerDAO.Create(customer);
            return customer;
        }

        [HttpDelete]
        public int Delete(int id)
        {
            
            CustomerDAO.Delete(id);
            return 1;
        }
    }
}
