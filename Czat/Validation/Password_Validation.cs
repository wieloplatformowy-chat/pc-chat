using System.Globalization;
using System.Windows.Controls;

namespace MaterialDesignColors.WpfExample
{
    public class Login_Validation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Złe hasło.")
                : ValidationResult.ValidResult;
        }
    }
}
