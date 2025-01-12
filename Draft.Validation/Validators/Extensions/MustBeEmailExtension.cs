using Draft.Validation.Validators.Rules;

namespace Draft.Validation.Validators.Extensions;

public static class MustBeEmailExtension
{
	public static FluentValidator<string> MustBeEmail(this FluentValidator<string> validator)
	{
		return validator.AddRule(new EmailRuleStrategy());
	}
}
