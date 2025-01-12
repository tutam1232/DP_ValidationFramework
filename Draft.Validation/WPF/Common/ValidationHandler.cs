using Draft.Validation.Abstract;
using System.ComponentModel;

namespace Draft.Validation.WPF.Common;

public class ValidationHandler
{
	public List<ValidationGUIAdapterBase> Rules { get; set; }

	[Browsable(false)]
	public List<ValidationDisplayBase> Displays { get; set; }

	public ValidationHandler()
	{
		Rules = new List<ValidationGUIAdapterBase>();
		Displays = new List<ValidationDisplayBase>();
	}

	public void Validate(string content)
	{
		List<ValidateResult> results = Rules.Select(rule => rule.Validate(content)).ToList();
		Displays.ForEach(display => display.Notify(results));
	}
}