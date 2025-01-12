namespace Draft.Validation.Validators;

public class ValidationResult
{
	public bool IsValid { get; set; } = true;
	public List<string> Errors { get; } = new();
}
