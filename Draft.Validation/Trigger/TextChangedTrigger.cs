using System.Windows.Controls;

namespace Draft.Validation.Trigger;

public class TextChangedTrigger : ValidationTriggerBase
{
	private void OnTextChanged(object sender, TextChangedEventArgs e)
	{
		TriggerValidate();
	}

	public override void Attach()
	{
		if (_textBox != null)
		{
			_textBox.TextChanged += OnTextChanged;
		}
	}

	public override void Detach()
	{
		if (_textBox != null)
		{
			_textBox.TextChanged -= OnTextChanged;
		}
	}
}
