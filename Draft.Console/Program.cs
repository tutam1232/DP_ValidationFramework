<<<<<<< Updated upstream
﻿namespace Draft.Console
=======
﻿

using DesignPattern.Attributes;
using DesignPattern.Validators;
using DesignPattern.Validators.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Draft.ConsoleValidator
>>>>>>> Stashed changes
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var emailResult = new FluentValidator<string>("invalid-email")
				.MustBeEmail()
				.MustHaveLength(5, 100)
				.Must(email => email.Contains("@"), "Must contain @")
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
}

//------------------- attribute test

class User
{
    [EmailValidation]
    [LengthValidation(5, 6)]
    [RegexChecking("^\\w+_\\w+$", ErrorMessage = "sai regex")]
    public string Email { get; set; }

    [Even]
    [RangeValidation(10, 20)]
    public int Number { get; set; }
}
