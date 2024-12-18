using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Validators.Rules;
using DesignPattern.Validators.Extensions;

namespace DesignPattern.Validators
{
    public class FluentValidator<T>
    {
        private readonly T _value;
        private readonly List<IValidationRuleStrategy<T>> _rules = new();
        private readonly ValidationResult _result = new();

        public FluentValidator(T value)
        {
            _value = value;
        }

        public FluentValidator<T> AddRule(IValidationRuleStrategy<T> strategy)
        {
            _rules.Add(strategy);
            return this;
        }
        public FluentValidator<T> Must(Func<T, bool> condition, string errorMessage)
        {
            return AddRule(new CustomRuleStrategy<T>(condition, errorMessage));
        }

        public ValidationResult Check()
        {
            foreach (var rule in _rules)
            {
                if (!rule.IsValid(_value))
                {
                    _result.IsValid = false;
                    _result.Errors.Add(rule.ErrorMessage);
                }
            }
            return _result;
        }
    }
}
