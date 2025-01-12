using Draft.Validation.Validators;
using Draft.Validation.WPF;
using System.Windows.Controls;
using System.Windows.Data;

namespace Draft.Validation.Abstract;

public abstract class ValidationTriggerBase
{
	protected TextBox? _textBox = null;

	protected ValidationTriggerBase()
	{
	}

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
		var handler = Source.GetHandler(_textBox) ?? throw new InvalidOperationException("Handler is not set.");

		// Rules from GUI
		var results = handler.ValidateGUIRules(_textBox.Text);

		// Rules from attribute if binded
		if (_textBox.GetBindingExpression(TextBox.TextProperty) is BindingExpression binding)
		{
			var attrResults = AttributeValidator.ValidateViaAttributeOfProperty(_textBox.DataContext, binding.ResolvedSourcePropertyName);
			results.AddRange(attrResults);
		}

		handler.DisplayResult(results);
	}

	public abstract void Attach();
	public abstract void Detach();
}
