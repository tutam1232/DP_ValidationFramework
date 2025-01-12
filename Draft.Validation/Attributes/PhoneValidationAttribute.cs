using System.ComponentModel.DataAnnotations;
using Draft.Validation.Services;

namespace Draft.Validation.Attributes;

public class PhoneValidationAttribute : ValidationAttribute
{
	public PhoneValidationAttribute()
	{
		ErrorMessage = "Invalid phone number";
	}

	public override bool IsValid(object? value)
	{
		if (value == null)
			return false;
		string phone = value.ToString();
		return ValidationServices.isPhone(phone);
	}
}
