using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Services;

namespace DesignPattern.Validators.Rules
{
    public class LengthRuleStrategy : IValidationRuleStrategy<string>
    {
        private readonly int _min;
        private readonly int _max;

        public LengthRuleStrategy(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public string ErrorMessage => $"Length must be between {_min} and {_max} characters";
        public bool IsValid(string value) =>
            ValidationServices.isLengthBetween(value, _min, _max);
    }
}
