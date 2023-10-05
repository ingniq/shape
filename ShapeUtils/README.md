
## Installation

Using the .NET Core command-line interface (CLI) tools:

```
dotnet add package ShapeUtils.04.10.23.001
```

## Usage

Import namespaces:

```csharp
using Ingniq.ShapeUtils.Shapes;
using Ingniq.ShapeUtils.GeometricMeasurements;
```

Create instance:

```csharp
CircleParameters circleParameters = new{
    Radius = new Radius(10)
};

TriangleParameters triangleParameters = new{
    SideA = new Side(3),
    SideB = new Side(4),
    SideC = new Side(5)
};

Shape circle = ShapeFactory.CreateShape(circleParameters);
Shape triangle = ShapeFactory.CreateShape(triangleParameters);
```

Calculate area:

```csharp
double circleArea = circle.CalculateArea();
double triangleArea = triangle.CalculateArea();
```

Checking the squareness of a triangle:

```csharp
bool isRightTriangle = triangle.IsRightTriangle();
```