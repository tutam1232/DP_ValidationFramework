using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Validators.Rules;

namespace DesignPattern.Validators.Extensions
{
    public static class CheckRegexExtension
    {
        public static FluentValidator<string> CheckRegex(this FluentValidator<string> validator, string pattern)
        {
            return validator.AddRule(new RegexRuleStrategy(pattern));
        }
    }
}
