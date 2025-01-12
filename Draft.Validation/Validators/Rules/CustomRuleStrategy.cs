using Draft.Validation.Abstract;

namespace Draft.Validation.Validators.Rules;

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
