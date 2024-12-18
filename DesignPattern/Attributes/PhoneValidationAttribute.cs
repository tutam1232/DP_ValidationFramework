using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Services;
using DesignPattern.Validators.Rules;

namespace DesignPattern.Attributes
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        public PhoneValidationAttribute()
        {
            ErrorMessage = "Invalid phone number";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            string phone = value.ToString();
            return ValidationServices.isPhone(phone);
        }
    }
}
