
using Draft.Validation.Abstract;
using Draft.Validation.WPF;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Draft.Validation.Display;

public class ToolTipDisplay : ValidationDisplayBase
{
	const int ICON_SIZE = 16;

	public override void DisplayError(ValidationDisplayControl validationDisplayControl, List<string?> messages)
	{
		Bitmap bitmap = SystemIcons.Error.ToBitmap();
		System.Windows.Controls.Image image = new System.Windows.Controls.Image()
		{
			Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions()),
			Width = ICON_SIZE,
			Height = ICON_SIZE
		};
		ToolTip toolTip = new ToolTip()
		{
			Content = string.Join(Environment.NewLine, messages),
			Background = System.Windows.Media.Brushes.Red,
			Foreground = System.Windows.Media.Brushes.White,
			PlacementTarget = validationDisplayControl
		};
		validationDisplayControl.ToolTip = toolTip;
		validationDisplayControl.Content = image;
	}

	public override void DisplayNormal(ValidationDisplayControl validationDisplayControl)
	{
		validationDisplayControl.ToolTip = null;
		validationDisplayControl.Content = null;
	}
}
