using Draft.Validation.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Draft.TestFramework;

public class MainWindowViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;
	protected void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	private string _attribute = string.Empty;
	
	[EmailValidation]
	public string Attribute
	{
		get => _attribute;
		set
		{
			if (_attribute != value)
			{
				_attribute = value;
				OnPropertyChanged(nameof(Attribute));
			}
		}
	}
	
	private string _fluentValidator = string.Empty;
	public string FluentValidator
	{
		get => _fluentValidator;
		set
		{
			if (_fluentValidator != value)
			{
				_fluentValidator = value;
				OnPropertyChanged(nameof(FluentValidator));
			}
		}
	}

	public MainWindowViewModel()
	{
	}
}
