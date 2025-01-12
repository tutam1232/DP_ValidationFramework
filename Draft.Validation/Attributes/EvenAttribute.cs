using System.ComponentModel.DataAnnotations;

namespace Draft.Validation.Attributes;

public class EvenAttribute : ValidationAttribute
{
	public EvenAttribute()
	{
		ErrorMessage = "The number must be even";
	}
	public override bool IsValid(object? value)
	{

		if (value == null)
			return false;
		if (value is int intValue)
			return intValue % 2 == 0;

		if (value is long longValue)
			return longValue % 2 == 0;

		if (value is decimal decimalValue)
			return decimalValue % 2 == 0;

		if (value is double doubleValue)
			return doubleValue % 2 == 0;

		if (value is string stringValue && int.TryParse(stringValue, out int number))
			return number % 2 == 0;

		return false;
	}

}
