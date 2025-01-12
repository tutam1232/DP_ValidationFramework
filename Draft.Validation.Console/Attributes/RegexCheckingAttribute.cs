using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DesignPattern.Services;
using DesignPattern.Validators.Rules;

namespace DesignPattern.Attributes
{
    public class RegexCheckingAttribute : ValidationAttribute
    {
        private readonly string _pattern;
        public RegexCheckingAttribute(string pattern)
        {
            _pattern = pattern;
            ErrorMessage = "Input does not match regex pattern";
        }
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            return ValidationServices.checkRegex(value.ToString(), _pattern);
        }
    }
}
