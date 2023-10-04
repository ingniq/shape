
using Ingniq.ShapeUtils.GeometricMeasurements;
using Ingniq.ShapeUtils.Shapes;

namespace Ingniq.ShapeUtils
{
    public struct TriangleParameters : IShapeParameters
    {
        public readonly ShapeType Type => ShapeType.Triangle;
        public Side? SideA;
        public Side? SideB;
        public Side? SideC;
        public Angle? AngleAB;
        public Angle? AngleAC;
        public Angle? AngleBC;
    }
}