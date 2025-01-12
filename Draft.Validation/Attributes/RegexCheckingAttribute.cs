using System.ComponentModel.DataAnnotations;
using Draft.Validation.Services;

namespace Draft.Validation.Attributes;

public class RegexCheckingAttribute : ValidationAttribute
{
	private readonly string _pattern;
	public RegexCheckingAttribute(string pattern)
	{
		_pattern = pattern;
		ErrorMessage = "Input does not match regex pattern";
	}
	public override bool IsValid(object value)
	{
		if (value == null)
			return false;
		return ValidationServices.checkRegex(value.ToString(), _pattern);
	}
}
