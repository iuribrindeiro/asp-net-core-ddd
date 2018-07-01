using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Attributes.ModelAttributes
{
    public class GuidValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Guid.TryParse(value.ToString(), out _))
                return ValidationResult.Success;
            
            return new ValidationResult("O id informado não é válido");
        }
    }
}