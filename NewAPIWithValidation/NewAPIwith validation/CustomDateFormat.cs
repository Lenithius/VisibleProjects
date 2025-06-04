using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace NewAPIWithValidation
{
    public class CustomDateFormat : ValidationAttribute
    {

        private readonly string? _dateFormat;

        public CustomDateFormat(string dateFormat)
        {
            _dateFormat = dateFormat;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) 
            { 
                return ValidationResult.Success; 
            }
            
            var dateString = value.ToString();

            if (DateTime.TryParseExact(dateString, _dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage ?? $"Invalid date format. Use {_dateFormat}");
        }
    }
}

