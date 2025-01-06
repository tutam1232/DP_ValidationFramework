using Draft.Validation.Common;

namespace Draft.Validation.Rule;

public class ValidateRequired : IValidationRule
{
	public ValidateResult Validate(string content)
	{
		if (string.IsNullOrEmpty(content))
		{
			return new ValidateResult { IsValid = false, Message = "This field is required" };
		}

		return new ValidateResult { IsValid = true };
	}
}
