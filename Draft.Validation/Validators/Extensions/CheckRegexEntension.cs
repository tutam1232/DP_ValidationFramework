using DesignPattern.Validators.Rules;

namespace Draft.Validation.Validators.Extensions
{
	public static class CheckRegexExtension
	{
		public static FluentValidator<string> CheckRegex(this FluentValidator<string> validator, string pattern)
		{
			return validator.AddRule(new RegexRuleStrategy(pattern));
		}
	}
}
