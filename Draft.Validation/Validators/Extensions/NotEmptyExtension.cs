using DesignPattern.Validators.Rules;

namespace Draft.Validation.Validators.Extensions;

public static class NotEmptyExtension
{
	public static FluentValidator<string> NotEmpty(this FluentValidator<string> validator)
	{
		return validator.AddRule(new NotEmptyRuleStrategy());
	}
}
