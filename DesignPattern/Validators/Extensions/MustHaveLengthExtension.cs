using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Validators.Rules;

namespace DesignPattern.Validators.Extensions
{
    public static class MustHaveLengthExtension
    {
        public static FluentValidator<string> MustHaveLength(this FluentValidator<string> validator, int min, int max)
        {
            return validator.AddRule(new LengthRuleStrategy(min, max));
        }
    }
}
