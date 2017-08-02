using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookstoreApp.Models;
using BookstoreApp.Models.ViewModels;

namespace BookstoreApp.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            return View();
        }
        // GET: Books/Random
/*        public ActionResult Random()
        {
            var book = new Book()
            {
                Id = 1000,
                Title = "Title of a Book"
            };

            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Dan"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Aziz"
                },
                new Customer
                {
                    Id = 3,
                    Name = "John"
                },
                
            };

            var randomBookViewModel = new RandomBookViewModel
            {
                RandomBook = book,
                Customers = customers
            };

            return View(randomBookViewModel);
        }*/





        public ActionResult GetJson()
        {
            var books = new List<Book>
            {
                new Book()
                {
                    Id = 100,
                    Title = "Windows XP"
                },
                new Book()
                {
                    Id = 200,
                    Title = "Clean Code"
                },
                new Book()
                {
                    Id = 300,
                    Title = "MVC ASP"
                }
            };

            return Json(books, JsonRequestBehavior.AllowGet);

            //return View();
        }
        public ActionResult Edit(int? id) // id = 0 or int? makes parameter optional
        {
            if (id.HasValue)
                return Content("Editing a book with id " + id);
            else
                return HttpNotFound();
        }
        [Route("books/ByReleaseDate/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + " " +month);
            
        }

    }
}

//return Content("Hello");
//return Redirect("Index");
//return HttpNotFound();
//return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});