using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Ingniq.ShapeUtils.GeometricMeasurements;

namespace Ingniq.ShapeUtils.Validators
{
    public class NonNegativeNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is Radius radius)
            {
                if (radius.Value >= 0)
                    return true;
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }
    }
}