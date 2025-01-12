using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Services;

namespace DesignPattern.Validators.Rules
{
    public class EvenRuleStrategy : IValidationRuleStrategy<int>
    {
        public string ErrorMessage => "Number is not even";
        public bool IsValid(int value) => ValidationServices.isEven(value);
    }
}
