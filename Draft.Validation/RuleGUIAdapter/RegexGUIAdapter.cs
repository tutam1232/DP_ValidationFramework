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

	public override ValidateResult Validate(string content)
	{
		var regexRuleStrategy = new RegexRuleStrategy(Pattern);
		var isValid = regexRuleStrategy.IsValid(content);
		var errorMessage = isValid ? null : regexRuleStrategy.ErrorMessage;
		return new ValidateResult() { IsValid = isValid, Message = errorMessage };
	}
}
