using Draft.Validation.Abstract;
using Draft.Validation.Validators.Rules;
using Draft.Validation.WPF.Common;

namespace Draft.Validation.RuleGUIAdapter;

public class EvenRuleGUIAdapter : ValidationGUIAdapterBase
{
	private readonly EvenRuleStrategy _evenRuleStrategy;

	public EvenRuleGUIAdapter()
	{
		_evenRuleStrategy = new EvenRuleStrategy();
	}

	public override ValidateResult Validate(string content)
	{
		var value = CastIntegerValue(content);
		var isValid = _evenRuleStrategy.IsValid(value);
		var errorMessage = isValid ? null : _evenRuleStrategy.ErrorMessage;
		return new ValidateResult() { IsValid = isValid, Message = errorMessage };
	}
}
