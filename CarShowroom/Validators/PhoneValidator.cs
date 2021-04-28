using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace CarShowroom.Validators
{
    public class PhoneValidator : ValidationRule
    {
        public string Message { get => "Phone is not valid"; }

        public Regex Regex { get; set; } = new Regex("^[+]*[-\\s\\./0-9]{0,3}[(]{0,2}[0-9]{2}[)]{0,1}[-\\s/0-9]{7,9}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Regex.IsMatch((string)value))
                return ValidationResult.ValidResult;
            
            return new ValidationResult(false, Message);
        }
    }
}