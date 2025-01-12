using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Validators.Rules;

namespace DesignPattern.Validators.Extensions
{
    public static class MustBeEmailExtension
    {
        public static FluentValidator<string> MustBeEmail(this FluentValidator<string> validator)
        {
            return validator.AddRule(new EmailRuleStrategy());
        }
    }
}
