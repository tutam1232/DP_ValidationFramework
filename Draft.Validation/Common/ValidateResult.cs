namespace Draft.Validation.Common;

public record ValidateResult 
{
	public bool IsValid { get; init; }
	public string? Message { get; init; }
}
