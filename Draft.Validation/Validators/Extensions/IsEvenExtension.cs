using DesignPattern.Validators.Rules;

namespace Draft.Validation.Validators.Extensions
{
	public static class IsEvenExtension
	{
		public static FluentValidator<int> IsEven(this FluentValidator<int> validator)
		{
			return validator.AddRule(new EvenRuleStrategy());
		}
	}
}
