using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Validators.Rules
{
    public class NotEmptyRuleStrategy : IValidationRuleStrategy<string>
    {
        public string ErrorMessage => "Value cannot be empty";
        public bool IsValid(string value) => !string.IsNullOrEmpty(value);
    }
}
