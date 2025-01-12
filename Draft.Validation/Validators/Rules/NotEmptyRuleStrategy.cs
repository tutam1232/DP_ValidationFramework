using Draft.Validation.Abstract;

namespace Draft.Validation.Validators.Rules;

public class NotEmptyRuleStrategy : IValidationRuleStrategy<string>
{
	public string ErrorMessage => "Value cannot be empty";
	public bool IsValid(string value) => !string.IsNullOrEmpty(value);
}
