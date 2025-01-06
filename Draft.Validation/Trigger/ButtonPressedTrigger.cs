using Draft.Validation.WPF;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Draft.Validation.Trigger;

public class ButtonPressedTrigger : ValidationTriggerBase
{
	private FrameworkElement? _triggerButton;

	[Category("Validation")]
	[Browsable(true)]
	[Description("The button that triggers the validation.")]
	public FrameworkElement? TriggerButton
	{
		get => _triggerButton;
		set
		{
			_triggerButton = value;
			_triggerButton?.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(OnButtonPressed));
		}
	}

	private void OnButtonPressed(object sender, RoutedEventArgs e)
	{
		TriggerValidate();
	}

	public override void Attach()
	{
	}

	public override void Detach()
	{
	}
}
