using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CombatTracker.WpfApplication.Validation
{
    public class IntParseValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.TryParse(value.ToString(), out int intValue))
                return new ValidationResult(true, null);
            return new ValidationResult(false, "Enter a valid integer");
        }
    }
}
