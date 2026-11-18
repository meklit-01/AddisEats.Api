using System.ComponentModel.DataAnnotations;

namespace AddisEats.Api.Validation;

public class ETBAmountAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext
    )
    {
        // Allow null values. Use [Required] if the field is mandatory.
        if (value == null)
            return ValidationResult.Success;

        // Check whether the value is a decimal and greater than zero.
        if (value is not decimal amount || amount <= 0)
        {
            return new ValidationResult(
                "Amount must be greater than zero."
            );
        }

        // Check whether the amount has more than two decimal places.
        if (decimal.Round(amount, 2) != amount)
        {
            return new ValidationResult(
                "Amount cannot have more than two decimal places."
            );
        }

        // If all checks pass, the amount is valid.
        return ValidationResult.Success;
    }
}
