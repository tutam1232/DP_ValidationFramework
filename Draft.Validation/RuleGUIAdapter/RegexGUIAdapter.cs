using Draft.Validation.Abstract;
using Draft.Validation.Validators.Rules;
using Draft.Validation.WPF.Common;
using System.ComponentModel;

namespace Draft.Validation.RuleGUIAdapter;

public class RegexGUIAdapter : ValidationGUIAdapterBase
{
	[Browsable(true)]
	[Description("Regex Pattern")]
	public string Pattern { get; set; } = string.Empty;

	[Browsable(true)]
	[Description("Regex Error message")]
	public string ErrorMessage { get; set; } = string.Empty;

	public override ValidateResult Validate(string content)
	{
		var regexRuleStrategy = new RegexRuleStrategy(Pattern, string.IsNullOrEmpty(ErrorMessage) ? null : ErrorMessage);
		var isValid = regexRuleStrategy.IsValid(content);
		var errorMessage = isValid ? null : regexRuleStrategy.ErrorMessage;
		return new ValidateResult() { IsValid = isValid, Message = errorMessage };
	}
}
