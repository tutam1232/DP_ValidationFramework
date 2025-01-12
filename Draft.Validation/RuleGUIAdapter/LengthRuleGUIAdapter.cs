using Draft.Validation.Abstract;
using Draft.Validation.Validators.Rules;
using Draft.Validation.WPF.Common;
using System.ComponentModel;

namespace Draft.Validation.RuleGUIAdapter;

public class LengthRuleGUIAdapter : ValidationGUIAdapterBase
{
	public LengthRuleGUIAdapter()
	{
	}

	private int _max = 1;
	private int _min = 0;

	[Browsable(true)]
	[Description("Minimum length")]
	public int Min
	{
		get => _min;
		set
		{
			_min = value;
		}
	}

	[Browsable(true)]
	[Description("Maximum length")]
	public int Max
	{
		get => _max;
		set
		{
			_max = value;
		}
	}

	public override ValidateResult Validate(string content)
	{
		if (Min >= Max)
		{
			throw new InvalidOperationException("Min value must be less than Max value");
		}
		var lengthRuleStrategy = new LengthRuleStrategy(Min, Max);
		var isValid = lengthRuleStrategy.IsValid(content);
		var errorMessage = isValid ? null : lengthRuleStrategy.ErrorMessage;
		return new ValidateResult() { IsValid = isValid, Message = errorMessage };
	}
}
