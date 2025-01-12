using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Validators.Rules;

namespace DesignPattern.Validators.Extensions
{
    public static class IsOddExtension
    {
        public static FluentValidator<int> IsOdd(this FluentValidator<int> validator)
        {
            return validator.AddRule(new OddRuleStrategy());
        }
    }
}
