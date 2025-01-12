using Draft.Validation.Abstract;
using Draft.Validation.Validators.Rules;
using Draft.Validation.WPF.Common;

namespace DesignPattern.Validators.Rules;

public class EvenRuleGUIAdapter : ValidationGUIAdapterBase
{
	private readonly EvenRuleStrategy _evenRuleStrategy;

	public EvenRuleGUIAdapter()
	{
		_evenRuleStrategy = new EvenRuleStrategy();
	}

	public override ValidateResult Validate(string content)
	{
		var result = IsIntegerValue(content, out int intValue);
		if (result != null)
		{
			return result;
		}
		var isValid = _evenRuleStrategy.IsValid(intValue);
		var errorMessage = isValid ? null : _evenRuleStrategy.ErrorMessage;
		return new ValidateResult() { IsValid = isValid, Message = errorMessage };
	}
}
