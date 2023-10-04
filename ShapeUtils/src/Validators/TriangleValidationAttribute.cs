using System.ComponentModel.DataAnnotations;
using Ingniq.ShapeUtils.Shapes;

namespace Ingniq.ShapeUtils.Validators
{
    public class TriangleValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is Triangle triangle)
            {
                List<string> errors = new();

                ValidationSides(triangle, errors);
                ValidationOverflow(triangle, errors);

                double? a = triangle.SideA?.Value;
                double? b = triangle.SideB?.Value;
                double? c = triangle.SideC?.Value;

                if (
                    a != null && a > 0 &&
                    b != null && b > 0 &&
                    c != null && c > 0
                )
                {
                    ValidationOfExistance(triangle, errors);
                }

                if (errors.Count > 0)
                {
                    ErrorMessage = String.Join("\n", errors);
                    return false;
                }

                return true;
            }

            return false;
        }

        private static void ValidationOfExistance(Triangle triangle, List<string> errors)
        {
            double? a = triangle.SideA?.Value;
            double? b = triangle.SideB?.Value;
            double? c = triangle.SideC?.Value;

            if (
                a + b < c ||
                a + c < b ||
                b + c < a
            )
            {
                errors.Add("One side of the triangle is greater than the sum of the other two sides. Such a triangle cannot exist.");
            }
        }

        private static void ValidationOverflow(Triangle triangle, List<string> errors)
        {
            double? a = triangle.SideA?.Value;
            double? b = triangle.SideB?.Value;
            double? c = triangle.SideC?.Value;

            if (
                a != null &&
                b != null &&
                double.IsInfinity((double)a + (double)b)
            )
            {
                errors.Add("Arithmetic operation resulted in an overflow.");
            }
            else if (
                a != null &&
                c != null &&
                double.IsInfinity((double)a + (double)c)
            )
            {
                errors.Add("Arithmetic operation resulted in an overflow.");
            }
            else if (
                b != null &&
                c != null &&
                double.IsInfinity((double)b + (double)c)
            )
            {
                errors.Add("Arithmetic operation resulted in an overflow.");
            }
            else if (
                a != null &&
                b != null &&
                c != null &&
                double.IsInfinity((double)a + (double)b + (double)c)
            )
            {
                errors.Add("Arithmetic operation resulted in an overflow.");
            }
        }

        private static void ValidationSides(Triangle triangle, List<string> errors)
        {
            double? a = triangle.SideA?.Value;
            double? b = triangle.SideB?.Value;
            double? c = triangle.SideC?.Value;

            if (a != null && (a <= 0 || Double.IsInfinity((double)a)))
            {
                errors.Add("SideA: invalid value.");
            }

            if (b != null && (b <= 0 || Double.IsInfinity((double)b)))
            {
                errors.Add("SideB: invalid value.");
            }

            if (c != null && (c <= 0 || Double.IsInfinity((double)c)))
            {
                errors.Add("SideC: invalid value.");
            }
        }
    }
}