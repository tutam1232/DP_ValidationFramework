using Draft.Validation.Abstract;
using Draft.Validation.Validators.Rules;
using Draft.Validation.WPF.Common;

namespace Draft.Validation.RuleGUIAdapter;

public class OddRuleGUIAdapter : ValidationGUIAdapterBase
{
	private readonly OddRuleStrategy _oddRuleStrategy;
	public OddRuleGUIAdapter()
	{
		_oddRuleStrategy = new OddRuleStrategy();
	}

	public override ValidateResult Validate(string content)
	{
		var value = CastIntegerValue(content);
		var isValid = _oddRuleStrategy.IsValid(value);
		var errorMessage = isValid ? null : _oddRuleStrategy.ErrorMessage;
		return new ValidateResult() { IsValid = isValid, Message = errorMessage };
	}
}
