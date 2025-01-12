using Draft.Validation.WPF.Common;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Windows.Controls;

namespace Draft.Validation.Validators;

public static class AttributeValidator
{
	public static List<ValidateResult> ValidateViaAttributeAllProperties(object instance)
	{
		var validateResults = new List<ValidateResult>();
		try
		{
			var properties = instance.GetType().GetProperties();
			foreach (var property in properties)
			{
				if (property == null)
					continue;
				var attributes = property.GetCustomAttributes<ValidationAttribute>().ToList();
				if (attributes == null)
					continue;
				var value = property.GetValue(instance);
				validateResults.AddRange(attributes.Select(a => new ValidateResult()
				{
					IsValid = a.IsValid(value),
					Message = a.IsValid(value) ? null : a.ErrorMessage
				}).ToList());
			}
		}
		catch (Exception ex)
		{
			validateResults = new List<ValidateResult> { new ValidateResult() { IsValid = false, Message = ex.Message } };
		}
		return validateResults;
	}

	public static List<ValidateResult> ValidateViaAttributeOfProperty(object instance, string propertyName)
	{
		var validateResults = new List<ValidateResult>();
		try
		{
			var property = instance.GetType().GetProperty(propertyName) ?? throw new Exception("Property not found");
			var attributes = property.GetCustomAttributes<ValidationAttribute>().ToList();
			if (attributes == null)
			{
				return validateResults;
			}
			var value = property.GetValue(instance);
			validateResults.AddRange(attributes.Select(a => new ValidateResult()
			{
				IsValid = a.IsValid(value),
				Message = a.IsValid(value) ? null : a.ErrorMessage
			}).ToList());
		}
		catch (InvalidRuleFormartException ex)
		{
			validateResults = new List<ValidateResult> { new ValidateResult() { IsValid = false, Message = ex.Message } };
		}
		return validateResults;
	}
}
