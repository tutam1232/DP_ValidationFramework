using Draft.Validation.Abstract;
using System.ComponentModel;
using System.Windows;
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
		set =>_triggerButton = value;
	}

	private readonly RoutedEventHandler? _buttonPressedHandler;

	public ButtonPressedTrigger()
	{
		_buttonPressedHandler = OnButtonPressed;
	}

	private void OnButtonPressed(object sender, RoutedEventArgs e)
	{
		TriggerValidate();
	}

	public override void Attach()
	{
		_triggerButton?.AddHandler(ButtonBase.ClickEvent, _buttonPressedHandler);
	}

	public override void Detach()
	{
		_triggerButton?.RemoveHandler(ButtonBase.ClickEvent, _buttonPressedHandler);
	}
}
