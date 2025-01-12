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
    public class EvenAttribute : ValidationAttribute
    {
        public EvenAttribute()
        {
            ErrorMessage = "The number must be even";
        }
        public override bool IsValid(object? value)
        {

            if(value == null) return false;
            if (value is int intValue)
                return intValue % 2 == 0;

            if (value is long longValue)
                return longValue % 2 == 0;

            if (value is decimal decimalValue)
                return decimalValue % 2 == 0;

            if (value is double doubleValue)
                return doubleValue % 2 == 0;

            if (value is string stringValue && int.TryParse(stringValue, out int number))
                return number % 2 == 0;

            return false;
        }

    }
}
