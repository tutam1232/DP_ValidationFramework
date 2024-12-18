using DesignPattern.Validators;
using DesignPattern.Validators.Extensions;
using DesignPattern.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

// NOTE: this is for testing purpose only, not refactored yet
internal class Program
{
    private static void Main(string[] args)
    {
        string email = "invalid-email";
        var emailResult = new FluentValidator<string>(email)
            .MustBeEmail()
            .MustHaveLength(5, 100)
            .Must(email => email.Contains("@"), "Must contain @")
            .CheckRegex("^\\w+_\\w+$")
            .Check();

        var numberResult = new FluentValidator<int>(4)
            .MustInRange(5, 100)
            .IsEven()
            .Check();

        Console.WriteLine(emailResult.IsValid); // False

        //console log error
        foreach (var error in emailResult.Errors)
        {
            Console.WriteLine(error);
        }

        Console.WriteLine(numberResult.IsValid); // False

        //console log error
        foreach (var error in numberResult.Errors)
        {
            Console.WriteLine(error);
        }

        Console.WriteLine("----- Attribute Test -----");

        User user = new()
        {
            Email = "invalid_email",
            Number = 4
        };

        var properties = user.GetType().GetProperties();
        foreach (var property in properties)
        {
            foreach (var attribute in property.GetCustomAttributes<ValidationAttribute>())
            {
                var value = property.GetValue(user);
                if (!attribute.IsValid(value))
                {
                    Console.WriteLine($"{property.Name}: {attribute.ErrorMessage}");
                }
            }
        }


    }
}


//------------------- attribute test

class User
{
    [EmailValidation]
    [LengthValidation(5,10)]
    [RegexChecking("^\\w+_\\w+$", ErrorMessage = "sai regex")]
    public string Email { get; set; }

    [Even]
    [RangeValidation(10,20)]
    public int Number { get; set; }
}