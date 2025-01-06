
using Draft.Validation.WPF;
using System.Windows.Controls;
using System.Windows.Media;

namespace Draft.Validation.Display;

public class TextBlockDisplay : ValidationDisplayBase
{
	public override void DisplayError(ValidationDisplayControl validationDisplayControl, List<string?> messages)
	{
		StackPanel stackPanel = new StackPanel();
		foreach (var message in messages)
		{
			TextBlock textBlock = new TextBlock
			{
				Text = message,
				Foreground = Brushes.Red
			};
			stackPanel.Children.Add(textBlock);
		}
		if (validationDisplayControl != null)
		{
			validationDisplayControl.Content = stackPanel;
		}
	}

	public override void DisplayNormal(ValidationDisplayControl validationDisplayControl)
	{
		if (validationDisplayControl != null)
		{
			validationDisplayControl.Content = null;
		}
	}
}
