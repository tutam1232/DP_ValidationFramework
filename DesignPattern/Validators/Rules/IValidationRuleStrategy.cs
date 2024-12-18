using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Validators.Rules
{
    public interface IValidationRuleStrategy<T>
    {
        bool IsValid(T value);
        string ErrorMessage { get; }
    }
}
