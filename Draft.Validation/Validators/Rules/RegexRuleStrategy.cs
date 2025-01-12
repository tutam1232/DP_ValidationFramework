using Draft.Validation.Abstract;
using Draft.Validation.Services;

namespace Draft.Validation.Validators.Rules;

public class RegexRuleStrategy : IValidationRuleStrategy<string>
{
	private string _pattern;
	private string? _errorMessage;

	public RegexRuleStrategy(string pattern, string? errorMessage = null)
	{
		_pattern = pattern;
		_errorMessage = errorMessage;
	}

	public string ErrorMessage => _errorMessage ?? $"Did not match the regex pattern";
	public bool IsValid(string value) =>
		ValidationServices.checkRegex(value, _pattern);
}
