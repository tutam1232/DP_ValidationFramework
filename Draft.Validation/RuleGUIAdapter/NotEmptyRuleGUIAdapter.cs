using Draft.Validation.Abstract;
using Draft.Validation.Validators.Rules;
using Draft.Validation.WPF.Common;

namespace Draft.Validation.RuleGUIAdapter;

public class NotEmptyRuleGUIAdapter : ValidationGUIAdapterBase
{
	private readonly NotEmptyRuleStrategy _notEmptyRuleStrategy;
	public NotEmptyRuleGUIAdapter()
	{
		_notEmptyRuleStrategy = new NotEmptyRuleStrategy();
	}

	public override ValidateResult Validate(string content)
	{
		var isValid = _notEmptyRuleStrategy.IsValid(content);
		var errorMessage = isValid ? null : _notEmptyRuleStrategy.ErrorMessage;
		return new ValidateResult() { IsValid = isValid, Message = errorMessage };
	}
}
