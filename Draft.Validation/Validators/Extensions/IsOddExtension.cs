using Draft.Validation.Validators.Rules;

namespace Draft.Validation.Validators.Extensions;

public static class IsOddExtension
{
	public static FluentValidator<int> IsOdd(this FluentValidator<int> validator)
	{
		return validator.AddRule(new OddRuleStrategy());
	}
}
