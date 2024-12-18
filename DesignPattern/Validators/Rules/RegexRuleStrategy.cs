using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Services;

namespace DesignPattern.Validators.Rules
{
    public class RegexRuleStrategy : IValidationRuleStrategy<string>
    {
        private string _pattern;

        public RegexRuleStrategy(string pattern)
        {
            _pattern = pattern;
        }

        public string ErrorMessage => $"Did not match the regex pattern";
        public bool IsValid(string value) =>
            ValidationServices.checkRegex(value, _pattern);
    }
}
