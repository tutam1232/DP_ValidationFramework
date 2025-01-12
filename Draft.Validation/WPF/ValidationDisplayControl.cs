using System.Windows.Controls;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Draft.Validation.Abstract;
using Draft.Validation.WPF.Common;

namespace Draft.Validation.WPF;


public class ValidationDisplayControl : ContentControl
{
	/// <summary>
	/// Source attached property
	/// </summary>
	public static readonly DependencyProperty SourceProperty =
		DependencyProperty.Register(
			nameof(Source),
			typeof(TextBox),
			typeof(ValidationDisplayControl),
			new PropertyMetadata(null, OnSourceChanged));

	[Category("Validation")]
	[Browsable(true)]
	public TextBox Source
	{
		get => (TextBox)GetValue(SourceProperty);
		set => SetValue(SourceProperty, value);
	}

	// Todo: Clean this up
	private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ValidationDisplayControl displayer && displayer.Display != null)
		{
			if (e.OldValue is TextBox oldControl)
			{
				if (oldControl.GetValue(WPF.Source.HandlerProperty) is ValidationHandler handler)
				{
					handler.Displays.Remove(displayer.Display);
				}
			}
			if (e.NewValue is TextBox newControl)
			{
				if (newControl.GetValue(WPF.Source.HandlerProperty) is ValidationHandler handler)
				{
					handler.Displays.Add(displayer.Display);
				}
			}
		}
	}


	/// <summary>
	/// Display attached property
	/// </summary>
	public static readonly DependencyProperty DisplayProperty =
		DependencyProperty.Register(
			nameof(Display),
			typeof(ValidationDisplayBase),
			typeof(ValidationDisplayControl),
			new PropertyMetadata(null, OnDisplayChanged));

	[Category("Validation")]
	[Browsable(true)]
	public ValidationDisplayBase Display
	{
		get => (ValidationDisplayBase)GetValue(DisplayProperty);
		set => SetValue(DisplayProperty, value);
	}

	// Todo: Clean this up
	private static void OnDisplayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is ValidationDisplayControl displayer)
		{
			if (e.OldValue is ValidationDisplayBase oldDisplay)
			{
				if (displayer.Source?.GetValue(WPF.Source.HandlerProperty) is ValidationHandler handler)
				{
					handler.Displays.Remove(oldDisplay);
				}
			}
			if (e.NewValue is ValidationDisplayBase newDisplay)
			{
				newDisplay.Attach(displayer);
				if (displayer.Source?.GetValue(WPF.Source.HandlerProperty) is ValidationHandler handler)
				{
					handler.Displays.Add(newDisplay);
				}
			}
		}
	}
}

