using Draft.Validation.Abstract;
using System.ComponentModel;

namespace Draft.Validation.WPF.Common;

public class ValidationHandler
{
	public List<ValidationGUIAdapterBase> Rules { get; init; } = new();

	[Browsable(false)]
	public List<ValidationDisplayBase> Displays { get; init; } = new();

	public List<ValidateResult> ValidateGUIRules(string content)
	{
		var results = new List<ValidateResult>();
		try
		{
			foreach (var rule in Rules)
			{
				var result = rule.Validate(content);
				results.Add(result);
			}
		}
		catch (InvalidRuleFormartException ex)
		{
			results = new List<ValidateResult> { new ValidateResult() { IsValid = false, Message = ex.Message } };
		}
		return results;
	}

	public void DisplayResult(List<ValidateResult> results)
	{
		Displays.ForEach(display => display.Notify(results));
	}
}