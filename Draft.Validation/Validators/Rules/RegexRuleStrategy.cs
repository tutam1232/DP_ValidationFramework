using Draft.Validation.Abstract;
using Draft.Validation.Services;

namespace Draft.Validation.Validators.Rules;

public class RegexRuleStrategy : IValidationRuleStrategy<string>
{
	private string _pattern;

	public RegexRuleStrategy(string pattern)
	{
		_pattern = pattern;
	}

	public string ErrorMessage => $"Did not match the regex pattern";
	public bool IsValid(string value) =>
		ValidationServices.checkRegex(value, _pattern);
}
