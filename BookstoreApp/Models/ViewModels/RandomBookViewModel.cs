using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreApp.Models.ViewModels
{
    public class RandomBookViewModel
    {
        public Book RandomBook { get; set; }
        public List<Customer> Customers { get; set; }
    }
}