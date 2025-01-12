using Draft.Validation.Validators.Rules;

namespace Draft.Validation.Validators.Extensions;

public static class MustInRangeExtension
{
	public static FluentValidator<int> MustInRange(this FluentValidator<int> validator, int min, int max)
	{
		return validator.AddRule(new RangeRuleStrategy(min, max));
	}
}
