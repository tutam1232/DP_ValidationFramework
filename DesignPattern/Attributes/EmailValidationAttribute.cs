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
    public class EmailValidationAttribute: ValidationAttribute
    {
        public EmailValidationAttribute() {
            ErrorMessage = "Invalid email";
        }
        public override bool IsValid(object? value)      
        {

            if (value == null) return false;
            string email = value.ToString();
            return ValidationServices.isEmail(email);
        }
    }
}
