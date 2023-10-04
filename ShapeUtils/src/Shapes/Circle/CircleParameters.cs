using Ingniq.ShapeUtils.GeometricMeasurements;

namespace Ingniq.ShapeUtils.Shapes
{
    public struct CircleParameters : IShapeParameters
    {
        public readonly ShapeType Type => ShapeType.Circle;
        public Radius Radius;
    }
}