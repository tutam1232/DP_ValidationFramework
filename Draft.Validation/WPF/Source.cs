using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Draft.Validation.WPF;

public static class Source
{
	/// <summary>
	/// Rules attached property
	/// </summary>
	public static readonly DependencyProperty RulesProperty =
		DependencyProperty.RegisterAttached(
			"Rules",
			typeof(List<IValidationRule>),
			typeof(Source),
			new PropertyMetadata(new List<IValidationRule>()));


	[Category("Validation")]
	[Browsable(true)]
	[DisplayName("Rules")]
	[AttachedPropertyBrowsableForType(typeof(TextBox))]
	public static List<IValidationRule> GetRules(DependencyObject element)
	{
		return (List<IValidationRule>)element.GetValue(RulesProperty);
	}


	/// <summary>
	/// Handler attached property (hidden)
	/// </summary>
	public static readonly DependencyProperty HandlerProperty =
		DependencyProperty.RegisterAttached(
			"Handler",
			typeof(IValidationHandler),
			typeof(Source),
			new PropertyMetadata(new IValidationHandler()));

	[Browsable(false)]
	public static IValidationHandler GetHandler(DependencyObject element)
	{
		var handler = (IValidationHandler)element.GetValue(HandlerProperty);
		var rules = GetRules(element);
		handler.Rules = rules;
		return (IValidationHandler)element.GetValue(HandlerProperty);
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
