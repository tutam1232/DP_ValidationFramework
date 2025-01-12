using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Services;

namespace DesignPattern.Validators.Rules
{
    public class EmailRuleStrategy : IValidationRuleStrategy<string>
    {
        public string ErrorMessage => "Must be a valid email address";
        public bool IsValid(string value) =>
            ValidationServices.isEmail(value);
    }
}
