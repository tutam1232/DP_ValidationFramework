using Draft.Validation.Common;
using Draft.Validation.WPF;
using System.Windows;
using System.Windows.Controls;

namespace Draft.Validation;

public abstract class ValidationTriggerBase
{
	protected TextBox? _textBox = null;
	public void SetTextBox(TextBox textBox)
	{
		_textBox = textBox;
	}

	protected void TriggerValidate()
	{
		if (_textBox == null)
		{
			throw new InvalidOperationException("TextBox is not set.");
		}
		Source.GetHandler(_textBox).Validate(_textBox.Text);
	}

	public abstract void Attach();
	public abstract void Detach();
}

public interface IValidationRule
{
	ValidateResult Validate(string content);
}

public class IValidationHandler
{
	public List<IValidationRule> Rules { get; set; } = [];
	public List<ValidationDisplayBase> Displays { get; set; } = [];

	public void Validate(string content)
	{
		List<ValidateResult> results = Rules.Select(rule => rule.Validate(content)).ToList();
		Displays.ForEach(display => display.Notify(results));
	}
}

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

