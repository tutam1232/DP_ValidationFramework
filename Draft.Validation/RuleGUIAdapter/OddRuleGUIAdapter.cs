using DesignPattern.Services;
using Draft.Validation.Abstract;
using Draft.Validation.Validators.Rules;
using Draft.Validation.WPF.Common;

namespace DesignPattern.Validators.Rules
{
	public class OddRuleGUIAdapter : ValidationGUIAdapterBase
	{
		private readonly OddRuleStrategy _oddRuleStrategy;
        public OddRuleGUIAdapter()
        {
            _oddRuleStrategy = new OddRuleStrategy();
        }

        public override ValidateResult Validate(string content)
		{
			var result = IsIntegerValue(content, out int intValue);
			if (result != null)
			{
				return result;
			}
			var isValid = _oddRuleStrategy.IsValid(intValue);
			var errorMessage = isValid ? null : _oddRuleStrategy.ErrorMessage;
			return new ValidateResult() { IsValid = isValid, Message = errorMessage };
		}
	}
}
