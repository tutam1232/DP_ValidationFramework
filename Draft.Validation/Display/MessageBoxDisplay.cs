using Draft.Validation.Abstract;
using Draft.Validation.WPF;
using System.Windows;

namespace Draft.Validation.Display;

public class MessageBoxDisplay : ValidationDisplayBase
{
	public override void DisplayError(ValidationDisplayControl validationDisplayControl, List<string?> messages)
	{
		MessageBox.Show(string.Join(Environment.NewLine, messages), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
	}

	public override void DisplayNormal(ValidationDisplayControl validationDisplayControl)
	{
		// Do nothing
	}
}
