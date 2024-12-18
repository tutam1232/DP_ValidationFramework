using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Validators.Rules;

namespace DesignPattern.Validators.Extensions
{
    public static class MustInRangeExtension
    {
        public static FluentValidator<int> MustInRange(this FluentValidator<int> validator, int min, int max)
        {
            return validator.AddRule(new RangeRuleStrategy(min, max));
        }
    }
}
