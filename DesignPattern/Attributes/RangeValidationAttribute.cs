using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DesignPattern.Services;

namespace DesignPattern.Attributes
{
    public class RangeValidationAttribute : ValidationAttribute
    {
        private readonly int _minimum;
        private readonly int _maximum;

        public RangeValidationAttribute(int minimum, int maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
            ErrorMessage = $"Value must be between {_minimum} and {_maximum}";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;

            if (int.TryParse(value.ToString(), out int number))
            {
                return ValidationServices.isInRange(number, _minimum, _maximum);
            }
            return false;
        }

    }
}