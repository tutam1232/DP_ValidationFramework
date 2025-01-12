namespace Draft.Validation.Abstract;

public interface IValidationRuleStrategy<T>
    {
        abstract bool IsValid(T value);
        string ErrorMessage { get; }
    }
