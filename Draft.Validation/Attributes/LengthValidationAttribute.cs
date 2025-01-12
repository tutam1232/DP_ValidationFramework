using System.ComponentModel.DataAnnotations;
using Draft.Validation.Services;

namespace Draft.Validation.Attributes;

public class LengthValidationAttribute : ValidationAttribute
{
	private readonly int _minLength;
	private readonly int _maxLength;

	public LengthValidationAttribute(int minLength, int maxLength)
	{
		_minLength = minLength;
		_maxLength = maxLength;
		ErrorMessage = $"The field must be between {_minLength} and {_maxLength} characters long.";
	}

	public override bool IsValid(object? value)
	{
		if (value == null)
			return _minLength == 0;

		string str = value.ToString()!;
		return ValidationServices.isLengthBetween(str, _minLength, _maxLength);
	}
}