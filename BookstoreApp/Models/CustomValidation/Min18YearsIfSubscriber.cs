using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookstoreApp.Models.CustomValidation
{
    public class Min18YearsIfSubscriber: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            
            if(!customer.IsSubscriber)
                return ValidationResult.Success;
            if(DateTime.Today.Year - customer.BirthDate.Year < 18)
                return new ValidationResult("Age should be atleast 18 to become subscriber");
            return ValidationResult.Success;
        }
    }
}