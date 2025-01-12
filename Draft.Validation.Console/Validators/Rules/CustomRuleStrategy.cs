using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Validators.Rules
{
    public class CustomRuleStrategy<T> : IValidationRuleStrategy<T>
    {
        private readonly Func<T, bool> _condition;
        public string ErrorMessage { get; }

        public CustomRuleStrategy(Func<T, bool> condition, string errorMessage)
        {
            _condition = condition;
            ErrorMessage = errorMessage;
        }

        public bool IsValid(T value) => _condition(value);
    }
}
