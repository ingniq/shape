using System.ComponentModel.DataAnnotations;

namespace Ingniq.ShapeUtils.Shapes
{
    public abstract class Shape
    {
        public abstract double CalculateArea();

        public void Validate()
        {
            List<ValidationResult> results = new();
            ValidationContext context = new(this);

            if (Validator.TryValidateObject(this, context, results, true) != true)
            {
                throw new ValidationException(String.Join("\n", results.Select(error => error.ErrorMessage)));
            }
        }
    }
}