using Draft.Validation.Abstract;
using Draft.Validation.Validators.Rules;
using Draft.Validation.WPF.Common;

namespace Draft.Validation.RuleGUIAdapter;

public class EmailRuleGUIAdapter : ValidationGUIAdapterBase
{
	private readonly EmailRuleStrategy _emailRuleStrategy;

	public EmailRuleGUIAdapter()
	{
		_emailRuleStrategy = new EmailRuleStrategy();
	}

	public override ValidateResult Validate(string content)
	{
		var isValid = _emailRuleStrategy.IsValid(content);
		var errorMessage = isValid ? null : _emailRuleStrategy.ErrorMessage;
		return new ValidateResult() { IsValid = isValid, Message = errorMessage };
	}
}
