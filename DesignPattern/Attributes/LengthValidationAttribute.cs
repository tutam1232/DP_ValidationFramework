using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DesignPattern.Services;

namespace DesignPattern.Attributes
{
    public class LengthValidationAttribute : ValidationAttribute
    {
        private readonly int _minLength;
        private readonly int _maxLength;

        public LengthValidationAttribute(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
            ErrorMessage = $"The field must be between {_minLength} and {_maxLength} characters long.";
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return _minLength == 0;

            string str = value.ToString()!;
            return ValidationServices.isLengthBetween(str,_minLength,_maxLength);
        }
    }
}