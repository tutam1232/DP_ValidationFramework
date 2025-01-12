using Draft.Validation.Abstract;
using Draft.Validation.WPF.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Draft.Validation.WPF;

public static class Source
{
	static Source()
	{
		EventManager.RegisterClassHandler(typeof(TextBox), TextBoxBase.TextChangedEvent, new TextChangedEventHandler(OnTextBoxTextChanged), true);
	}

	private static void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
	{
		if (sender is TextBox textBox && GetHandler(textBox) is ValidationHandler handler)
		{
			var validateResults = new List<ValidateResult>();
			var instance = textBox.DataContext;
			var properties = instance.GetType().GetProperties();
			foreach (var property in properties)
			{
				var attributes = property.GetCustomAttributes<ValidationAttribute>().ToList();

				validateResults.AddRange(attributes.Select(a => new ValidateResult()
				{
					IsValid = a.IsValid(property.GetValue(instance)),
					Message = a.IsValid(property.GetValue(instance)) ? null : a.ErrorMessage
				}).ToList());
			}
			handler.Displays.ForEach(d => d.Notify(validateResults));
		}
	}

	/// <summary>
	/// Handler attached property (hidden)
	/// </summary>
	public static readonly DependencyProperty HandlerProperty =
		DependencyProperty.RegisterAttached(
			"Handler",
			typeof(ValidationHandler),
			typeof(Source),
			new PropertyMetadata(null, OnValidationHandlerChanged));

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


