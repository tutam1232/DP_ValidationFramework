using Draft.Validation.Abstract;

namespace Draft.Validation.WPF.Common;

public class ValidationHandler
{
    public List<ValidationGUIAdapterBase> Rules { get; set; } = [];
    public List<ValidationDisplayBase> Displays { get; set; } = [];

    public void Validate(string content)
    {
        List<ValidateResult> results = Rules.Select(rule => rule.Validate(content)).ToList();
        Displays.ForEach(display => display.Notify(results));
    }
}