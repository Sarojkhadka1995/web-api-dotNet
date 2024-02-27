using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Validations;

public class Shirt_EnsureCorrectSizingAttribute :ValidationAttribute
{
    protected override ValidationResult? IsValid(Object? value, ValidationContext validationContext)
    {
        var shirt = validationContext.ObjectInstance as Shirt;

        if (shirt != null && !string.IsNullOrWhiteSpace(shirt.Gender))
        {
            if (!shirt.Gender.Equals("male", StringComparison.OrdinalIgnoreCase) &&
                !shirt.Gender.Equals("female", StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult("Invalid gender");
            }
            if (shirt.Gender.Equals("male", StringComparison.OrdinalIgnoreCase) && shirt.Size < 8)
            {
                return new ValidationResult("For male shirt, the size has to be greater or equal to 8");
            }
            else if(shirt.Gender.Equals("female", StringComparison.OrdinalIgnoreCase) && shirt.Size < 6)
            {
                return new ValidationResult("For Female, the size has to be less then 6");
            }
        }
        return ValidationResult.Success;
    }
}