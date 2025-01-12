using Draft.Validation.Abstract;
using Draft.Validation.Services;

namespace Draft.Validation.Validators.Rules;

public class EvenRuleStrategy : IValidationRuleStrategy<int>
{
	public string ErrorMessage => "Number is not even";
	public bool IsValid(int value) => ValidationServices.isEven(value);
}
