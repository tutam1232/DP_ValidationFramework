using Draft.Validation.WPF.Common;

namespace Draft.Validation.Abstract;

public abstract class ValidationGUIAdapterBase
{
	/// <summary>
	/// Use for validation of integer value.
	/// </summary>
	/// <param name="content"></param>
	/// <returns></returns>
	protected static int CastIntegerValue(string content)
	{
		if (int.TryParse(content, out int value))
		{
			return value;
		}
		throw new InvalidRuleFormartException("Invalid format for Integer validation rule");
	}

	public abstract ValidateResult Validate(string content);
}
