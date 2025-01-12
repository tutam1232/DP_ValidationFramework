using System.ComponentModel;
using Draft.Validation.Abstract;
using Draft.Validation.Services;
using Draft.Validation.Validators.Rules;
using Draft.Validation.WPF.Common;

namespace Draft.Validation.RuleGUIAdapter;

public class RangeRuleGUIAdapter : ValidationGUIAdapterBase
{
	private int _max = 1;
	private int _min = 0;

	[Browsable(true)]
	[Description("Minimum value")]
	public int Min
	{
		get => _min;
		set
		{
			if (value >= _max)
			{
				throw new ArgumentException("Min value must be less than Max value");
			}
			_min = value;
		}
	}

	[Browsable(true)]
	[Description("Maximum value")]
	public int Max
	{
		get => _max;
		set
		{
			if (value <= _min)
			{
				throw new ArgumentException("Max value must be greater than Min value");
			}
			_max = value;
		}
	}

	public string ErrorMessage => $"Value must be between {_min} and {_max}";
	public bool IsValid(int value) => ValidationServices.isInRange(value, _min, _max);

	public override ValidateResult Validate(string content)
	{
		var rangeRuleStrategy = new RangeRuleStrategy(Min, Max);
		var result = IsIntegerValue(content, out int intValue);
		if (result != null)
		{
			return result;
		}
		var isValid = rangeRuleStrategy.IsValid(intValue);
		var errorMessage = isValid ? null : rangeRuleStrategy.ErrorMessage;
		return new ValidateResult() { IsValid = isValid, Message = errorMessage };
	}
}
