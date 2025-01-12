using Draft.Validation.Abstract;
using Draft.Validation.Services;

namespace Draft.Validation.Validators.Rules;

public class EmailRuleStrategy : IValidationRuleStrategy<string>
{
	public string ErrorMessage => "Must be a valid email address";
	public bool IsValid(string value) =>
		ValidationServices.isEmail(value);
}
