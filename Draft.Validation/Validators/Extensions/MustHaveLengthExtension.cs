using Draft.Validation.Validators.Rules;

namespace Draft.Validation.Validators.Extensions;

public static class MustHaveLengthExtension
{
	public static FluentValidator<string> MustHaveLength(this FluentValidator<string> validator, int min, int max)
	{
		return validator.AddRule(new LengthRuleStrategy(min, max));
	}
}
