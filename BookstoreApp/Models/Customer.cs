using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BookstoreApp.Models.CustomValidation;

namespace BookstoreApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]

        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfSubscriber]
        public DateTime BirthDate { get; set; }

        public bool IsSubscriber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}