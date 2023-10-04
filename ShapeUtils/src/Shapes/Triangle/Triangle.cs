using Ingniq.ShapeUtils.GeometricMeasurements;
using Ingniq.ShapeUtils.Validators;

namespace Ingniq.ShapeUtils.Shapes
{
    [TriangleValidation]
    public sealed class Triangle : Shape
    {
        public Side? SideA { get; }
        public Side? SideB { get; }
        public Side? SideC { get; }

        public Triangle(Side sideA, Side sideB, Side sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            Validate();
        }

        public Triangle(Side sideA, Side sideB, Angle angleAB)
        {
            throw new NotImplementedException();
        }
        public Triangle(Side side, Angle angle1, Angle angle2)
        {
            throw new NotImplementedException();
        }

        public override double CalculateArea()
        {
            if (SideA == null || SideB == null || SideC == null)
            {
                throw new NotImplementedException("The area calculation is implemented only for using the Heron formula. It is necessary to have measurements of all three sides.");
            }

            double a = SideA.Value.Value;
            double b = SideB.Value.Value;
            double c = SideC.Value.Value;

            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            if (Double.IsInfinity(area))
            {
                throw new OverflowException("Arithmetic operation resulted in an overflow.");
            }

            return area;
        }

        public bool IsRightTriangle()
        {
            if (SideA == null || SideB == null || SideC == null)
            {
                throw new NotImplementedException("Verification is carried out through the Pythagorean theorem only. It is necessary to have measurements of all three sides.");
            }

            double sideA = SideA.Value.Value;
            double sideB = SideB.Value.Value;
            double sideC = SideC.Value.Value;

            double[] sides = { sideA, sideB, sideC };
            Array.Sort(sides);
            return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
        }
    }
}