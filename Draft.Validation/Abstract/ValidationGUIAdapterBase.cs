using Draft.Validation.WPF.Common;

namespace Draft.Validation.Abstract;

public abstract class ValidationGUIAdapterBase
{
	/// <summary>
	/// Use for validation of integer value.
	/// </summary>
	/// <param name="content"></param>
	/// <returns></returns>
	protected static ValidateResult? IsIntegerValue(string content, out int intValue)
	{
		intValue = 0;
		if (int.TryParse(content, out int value))
		{
			intValue = value;
			return null;
		}
		return new ValidateResult() { IsValid = false, Message = "This is not an integer." };
	}

	public abstract ValidateResult Validate(string content);
}
