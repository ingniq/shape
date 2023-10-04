using Ingniq.ShapeUtils.GeometricMeasurements;

namespace Ingniq.ShapeUtils.Shapes
{
    public class ShapeFactory
    {
        public static Shape CreateShape(IShapeParameters shapeParameters)
        {
            return shapeParameters.Type switch
            {
                ShapeType.Circle => CreateCircle((CircleParameters)shapeParameters),
                ShapeType.Triangle => CreateTriangle((TriangleParameters)shapeParameters),
                _ => throw new NotImplementedException(),
            };
        }

        private static Circle CreateCircle(CircleParameters shapeParameters)
        {
            return new Circle(shapeParameters.Radius);
        }

        private static Triangle CreateTriangle(TriangleParameters shapeParameters)
        {
            if (
                shapeParameters.SideA != null &&
                shapeParameters.SideB != null &&
                shapeParameters.SideC != null
            )
            {
                return new Triangle((Side)shapeParameters.SideA, (Side)shapeParameters.SideB, (Side)shapeParameters.SideC);

            }

            throw new NotImplementedException("The creation of a triangle is implemented only on the basis of three sides.");
        }
    }
}

