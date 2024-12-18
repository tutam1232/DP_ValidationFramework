using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Services;

namespace DesignPattern.Validators.Rules
{
    public class OddRuleStrategy : IValidationRuleStrategy<int>
    {
        public string ErrorMessage => "Number is not odd";
        public bool IsValid(int value) => ValidationServices.isOdd(value);
    }
}
