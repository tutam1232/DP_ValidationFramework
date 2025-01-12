using Draft.Validation.Abstract;
using Draft.Validation.WPF.Common;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Draft.Validation.WPF;

public static class Source
{
	/// <summary>
	/// Handler attached property (hidden)
	/// </summary>
	public static readonly DependencyProperty HandlerProperty =
		DependencyProperty.RegisterAttached(
			"Handler",
			typeof(ValidationHandler),
			typeof(Source),
			new PropertyMetadata(new ValidationHandler(), OnValidationHandlerChanged));

	private static void OnValidationHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
	}

	[Category("Validation")]
	[Browsable(true)]
	[DisplayName("Handler")]
	[AttachedPropertyBrowsableForType(typeof(TextBox))]
	public static ValidationHandler GetHandler(DependencyObject element)
	{
		return (ValidationHandler)element.GetValue(HandlerProperty);
	}

	public static void SetHandler(DependencyObject element, ValidationHandler value)
	{
		element.SetValue(HandlerProperty, value);
	}


	/// <summary>
	/// Trigger attached property
	/// </summary>
	public static readonly DependencyProperty TriggerProperty =
		DependencyProperty.RegisterAttached(
			"Trigger",
			typeof(ValidationTriggerBase),
			typeof(Source),
			new PropertyMetadata(null, OnTriggerChanged));

	[Category("Validation")]
	[Browsable(true)]
	[DisplayName("Trigger")]
	[AttachedPropertyBrowsableForType(typeof(TextBox))]
	public static ValidationTriggerBase GetTrigger(DependencyObject element)
	{
		return (ValidationTriggerBase)element.GetValue(TriggerProperty);
	}

	public static void SetTrigger(DependencyObject element, ValidationTriggerBase value)
	{
		element.SetValue(TriggerProperty, value);
	}

	private static void OnTriggerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is TextBox textBox)
		{
			ValidationTriggerBase? existingValue = GetTrigger(textBox);
			existingValue?.Detach();
			if (e.NewValue is ValidationTriggerBase newValue)
			{
				newValue.SetTextBox(textBox);
				newValue.Attach();
			}
		}
	}
}


