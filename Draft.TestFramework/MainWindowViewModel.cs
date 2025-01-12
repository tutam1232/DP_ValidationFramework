using Draft.Validation.Attributes;
using Draft.Validation.Validators;
using Draft.Validation.Validators.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;

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
	private string _errorMessages = string.Empty;

	public string FluentValidator
	{
		get => _fluentValidator;
		set
		{
			if (_fluentValidator != value)
			{
				var fluent = new FluentValidator<string>(value);
				fluent.MustBeEmail();
				fluent.MustHaveLength(5, 10);
				fluent.Must(x => x.Contains("gmail"), "Must contain 'gmail'");
				var result = fluent.Check();
				if (!result.IsValid)
				{
					ErrorMessages = string.Join(Environment.NewLine, result.Errors);
				}
				else
				{
					ErrorMessages = string.Empty;
				}
				_fluentValidator = value;
				OnPropertyChanged(nameof(FluentValidator));
			}
		}
	}

	public string ErrorMessages
	{
		get => _errorMessages;
		private set
		{
			_errorMessages = value;
			OnPropertyChanged(nameof(ErrorMessages));
		}
	}
	public MainWindowViewModel()
	{
	}
}
