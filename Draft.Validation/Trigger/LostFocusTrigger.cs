using Draft.Validation.Abstract;

namespace Draft.Validation.Trigger;

public class LostFocusTrigger : ValidationTriggerBase
{
	private void TextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
	{
		TriggerValidate();
	}

	public override void Attach()
	{
		if (_textBox != null)
		{
			_textBox.LostFocus += TextBox_LostFocus;
		}
	}

	public override void Detach()
	{
		if (_textBox != null)
		{
			_textBox.LostFocus -= TextBox_LostFocus;
		}
	}
}
