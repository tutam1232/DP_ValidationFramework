using Draft.Validation.Abstract;
using Draft.Validation.Services;

namespace Draft.Validation.Validators.Rules;

public class OddRuleStrategy : IValidationRuleStrategy<int>
{
	public string ErrorMessage => "Number is not odd";
	public bool IsValid(int value) => ValidationServices.isOdd(value);
}
