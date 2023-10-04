using Ingniq.ShapeUtils.GeometricMeasurements;
using Ingniq.ShapeUtils.Validators;

namespace Ingniq.ShapeUtils.Shapes
{
    public sealed class Circle : Shape
    {
        [NonNegativeNumber(ErrorMessage = "{0}: only positive number allowed.")]
        public Radius Radius { get; }

        public Circle(Radius radius)
        {
            Radius = radius;
            Validate();
        }

        public override double CalculateArea()
        {
            double area = Math.PI * Math.Pow(Radius.Value, 2);

            if (Double.IsInfinity(area))
            {
                throw new OverflowException("Arithmetic operation resulted in an overflow.");
            }

            return area;
        }
    }
}