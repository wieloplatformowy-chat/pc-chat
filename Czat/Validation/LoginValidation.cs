using System.Globalization;
using System.Windows.Controls;

namespace Czat.Validation
{
    public class LoginValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Zły login.")
                : ValidationResult.ValidResult;
        }
    }
}
