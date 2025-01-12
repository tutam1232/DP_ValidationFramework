using Draft.Validation.WPF;
using System.Windows.Controls;

namespace Draft.Validation.Abstract;

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
