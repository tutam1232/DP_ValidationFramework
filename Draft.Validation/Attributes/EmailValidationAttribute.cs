using System.ComponentModel.DataAnnotations;
using Draft.Validation.Services;

namespace Draft.Validation.Attributes;

public class EmailValidationAttribute : ValidationAttribute
{
	public EmailValidationAttribute()
	{
		ErrorMessage = "Invalid email";
	}
	public override bool IsValid(object? value)
	{

		if (value == null)
			return false;
		string email = value.ToString();
		return ValidationServices.isEmail(email);
	}
}
