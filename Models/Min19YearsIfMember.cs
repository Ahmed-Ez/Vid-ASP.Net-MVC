﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vid.Models
{
    public class Min19YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo) return ValidationResult.Success;
            if (customer.BirthDate == null) return new ValidationResult("BirthDate is required");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) ?
                ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 for membership");

        }
    }
}