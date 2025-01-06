using Draft.Validation.Common;
using System.ComponentModel;

namespace Draft.Validation.Rule;

public class ValidateIsDigitOnly : IValidationRule
{
	[Browsable(true)]
	[Category("Validation")]
	public string? ErrorMessage { get; set; }

	public ValidateResult Validate(string content)
	{
		if (!int.TryParse(content, out _))
		{
			return new ValidateResult { IsValid = false, Message = "This field must be digit only" };
		}

		return new ValidateResult { IsValid = true };
	}
}
