using System.Text.RegularExpressions;


namespace Draft.Validation.Services;

public class ValidationServices
{
	// string services
	public static bool checkRegex(string value, string pattern)
	{
		return Regex.IsMatch(value, pattern);
	}
	public static bool isEmail(string email)
	{
		return checkRegex(email, "^((?!\\.)[\\w\\-_.]*[^.])(@\\w+)(\\.\\w+(\\.\\w+)?[^.\\W])$");
	}

	public static bool isPhone(string phone)
	{
		return checkRegex(phone, "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$");
	}

	public static bool isLengthBetween(string value, int min, int max)
	{
		return value != null && value.Length >= min && value.Length <= max;
	}

	// int services

	public static bool isEven(int num)
	{
		return num % 2 == 0;
	}

	public static bool isOdd(int num)
	{
		return num % 2 != 0;
	}

	public static bool isInRange(int num, int min, int max)
	{
		return num >= min && num <= max;
	}
}
