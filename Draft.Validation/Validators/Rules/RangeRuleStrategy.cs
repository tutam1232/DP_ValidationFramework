using Draft.Validation.Abstract;
using Draft.Validation.Services;

namespace Draft.Validation.Validators.Rules;

public class RangeRuleStrategy : IValidationRuleStrategy<int>
{
	private readonly int _min;
	private readonly int _max;

	public RangeRuleStrategy(int min, int max)
	{
		_min = min;
		_max = max;
	}

	public string ErrorMessage => $"Value must be between {_min} and {_max}";
	public bool IsValid(int value) => ValidationServices.isInRange(value, _min, _max);
}
