using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace CarShowroom.Validators
{
    public class EmailValidator : ValidationRule
    {
        public bool IsValid { get; set; } = true;

        public string Message { get => "Email is not valid"; }

        public Regex Regex { get; set; } = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch((string)value))
            {
                IsValid = true;
                return ValidationResult.ValidResult;
            }

            IsValid = false;
            return new ValidationResult(false, Message);
        }
    }
}
