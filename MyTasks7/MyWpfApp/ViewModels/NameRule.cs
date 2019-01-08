using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyWpfApp.ViewModels
{
    public class NameRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = string.Empty;
            try
            {
                name = value.ToString();
            }
            catch (FormatException)
            {
                return new ValidationResult(false, "Value is not a valid name");
            }
            if (string.IsNullOrEmpty(name))
            {
                return new ValidationResult(false, "Please enter a Hero Name.");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
