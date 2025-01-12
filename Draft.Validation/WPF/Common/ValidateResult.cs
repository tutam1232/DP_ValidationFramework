namespace Draft.Validation.WPF.Common;

public record ValidateResult
{
    public bool IsValid { get; init; }
    public string? Message { get; init; }
}
