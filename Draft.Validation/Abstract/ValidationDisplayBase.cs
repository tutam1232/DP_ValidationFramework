using Draft.Validation.WPF;
using Draft.Validation.WPF.Common;

namespace Draft.Validation.Abstract;

public abstract class ValidationDisplayBase
{
	public ValidationDisplayBase()
	{
	}

	private ValidationDisplayControl? _validationDisplayControl = null;
	public void Attach(ValidationDisplayControl validationDisplayControl)
	{
		_validationDisplayControl = validationDisplayControl;
	}

	public void Notify(List<ValidateResult> results)
	{
		if (_validationDisplayControl == null)
		{
			throw new InvalidOperationException("ValidationDisplayControl is not attached.");
		}
		bool isValid = results.All(result => result.IsValid);
		if (isValid)
		{
			DisplayNormal(_validationDisplayControl);
		}
		else
		{
			List<string?> messages = results.Where(result => !result.IsValid).Select(result => result.Message).ToList();
			DisplayError(_validationDisplayControl, messages);
		}
	}

	public abstract void DisplayError(ValidationDisplayControl validationDisplayControl, List<string?> messages);
	public abstract void DisplayNormal(ValidationDisplayControl validationDisplayControl);
}

