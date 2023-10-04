using System.ComponentModel.DataAnnotations;
using Ingniq.ShapeUtils.GeometricMeasurements;
using Ingniq.ShapeUtils.Shapes;

namespace Ingniq.ShapeUtils.Tests;

[TestClass]
public class UnitTestTriangle
{
    [TestMethod]
    public void TestCreateTriangle()
    {
        Shape triangle;
        double triangleArea;
        TriangleParameters triangleParameters = new()
        {
            SideA = new Side(7.719472615821079E+76),
            SideB = new Side(7.719472615821079E+76),
            SideC = new Side(7.719472615821079E+76)
        };

        triangle = ShapeFactory.CreateShape(triangleParameters);
        triangleArea = triangle.CalculateArea();
        Assert.AreEqual(2.5803338391983863E+153, triangleArea);
    }

    [TestMethod]
    public void TestCreateTriangleWithZero()
    {
        Action act;
        ValidationException exception;
        TriangleParameters triangleParameters;

        triangleParameters = new()
        {
            SideA = new Side(0),
            SideB = new Side(0),
            SideC = new Side(0)
        };

        act = () => ShapeFactory.CreateShape(triangleParameters);
        exception = Assert.ThrowsException<ValidationException>(act);
        Assert.AreEqual(
            "SideA: invalid value.\nSideB: invalid value.\nSideC: invalid value.",
            exception.Message
        );

        triangleParameters = new()
        {
            SideA = new Side(0),
            SideB = new Side(10),
            SideC = new Side(5)
        };

        act = () => ShapeFactory.CreateShape(triangleParameters);
        exception = Assert.ThrowsException<ValidationException>(act);
        Assert.AreEqual(
            "SideA: invalid value.",
            exception.Message
        );

        triangleParameters = new()
        {
            SideA = new Side(10),
            SideB = new Side(0),
            SideC = new Side(5)
        };

        act = () => ShapeFactory.CreateShape(triangleParameters);
        exception = Assert.ThrowsException<ValidationException>(act);
        Assert.AreEqual(
            "SideB: invalid value.",
            exception.Message
        );

        triangleParameters = new()
        {
            SideA = new Side(10),
            SideB = new Side(5),
            SideC = new Side(0)
        };

        act = () => ShapeFactory.CreateShape(triangleParameters);
        exception = Assert.ThrowsException<ValidationException>(act);
        Assert.AreEqual(
            "SideC: invalid value.",
            exception.Message
        );
    }

    [TestMethod]
    public void TestCreateTriangleWithNegativeNumber()
    {
        Action act;
        ValidationException exception;
        TriangleParameters triangleParameters;

        triangleParameters = new()
        {
            SideA = new Side(-1),
            SideB = new Side(-1),
            SideC = new Side(-1)
        };

        act = () => ShapeFactory.CreateShape(triangleParameters);
        exception = Assert.ThrowsException<ValidationException>(act);
        Assert.AreEqual(
            "SideA: invalid value.\nSideB: invalid value.\nSideC: invalid value.",
            exception.Message
        );

        triangleParameters = new()
        {
            SideA = new Side(-1),
            SideB = new Side(10),
            SideC = new Side(2)
        };

        act = () => ShapeFactory.CreateShape(triangleParameters);
        exception = Assert.ThrowsException<ValidationException>(act);
        Assert.AreEqual(
            "SideA: invalid value.",
            exception.Message
        );

        triangleParameters = new()
        {
            SideA = new Side(1),
            SideB = new Side(-10),
            SideC = new Side(2)
        };

        act = () => ShapeFactory.CreateShape(triangleParameters);
        exception = Assert.ThrowsException<ValidationException>(act);
        Assert.AreEqual(
            "SideB: invalid value.",
            exception.Message
        );

        triangleParameters = new()
        {
            SideA = new Side(1),
            SideB = new Side(10),
            SideC = new Side(-2)
        };

        act = () => ShapeFactory.CreateShape(triangleParameters);
        exception = Assert.ThrowsException<ValidationException>(act);
        Assert.AreEqual(
            "SideC: invalid value.",
            exception.Message
        );
    }

    [TestMethod]
    public void TestCreateTriangleInequality()
    {
        Action act;
        ValidationException exception;
        TriangleParameters triangleParameters;

        triangleParameters = new()
        {
            SideA = new Side(10),
            SideB = new Side(1),
            SideC = new Side(3)
        };

        act = () => ShapeFactory.CreateShape(triangleParameters);
        exception = Assert.ThrowsException<ValidationException>(act);

        Assert.AreEqual(
            "One side of the triangle is greater than the sum of the other two sides. Such a triangle cannot exist.",
            exception.Message
        );
    }

    [TestMethod]
    public void TestCreateTriangleOverflow()
    {
        Action act;
        ValidationException exception;
        TriangleParameters triangleParameters;

        triangleParameters = new()
        {
            SideA = new Side(double.MaxValue),
            SideB = new Side(double.MaxValue),
            SideC = new Side(double.MaxValue)
        };

        act = () => ShapeFactory.CreateShape(triangleParameters);
        exception = Assert.ThrowsException<ValidationException>(act);

        Assert.AreEqual("Arithmetic operation resulted in an overflow.", exception.Message);
    }

    [TestMethod]
    public void TestCalculateAreaOverflow()
    {
        Action act;
        Shape triangle;
        OverflowException exception;
        TriangleParameters triangleParameters;

        triangleParameters = new()
        {
            SideA = new Side(double.MaxValue / 4),
            SideB = new Side(double.MaxValue / 4),
            SideC = new Side(double.MaxValue / 4)
        };

        triangle = ShapeFactory.CreateShape(triangleParameters);
        act = () => triangle.CalculateArea();
        exception = Assert.ThrowsException<OverflowException>(act);

        Assert.AreEqual("Arithmetic operation resulted in an overflow.", exception.Message);
    }

    [TestMethod]
    public void TestIsRightTriangle()
    {
        Triangle triangle;
        bool isRightTriangle;
        TriangleParameters triangleParameters;

        triangleParameters = new()
        {
            SideA = new Side(7.719472615821079E+76),
            SideB = new Side(7.719472615821079E+76),
            SideC = new Side(7.719472615821079E+76)
        };

        triangle = (Triangle)ShapeFactory.CreateShape(triangleParameters);
        isRightTriangle = triangle.IsRightTriangle();
        Assert.AreEqual(false, isRightTriangle);

        triangleParameters = new()
        {
            SideA = new Side(3),
            SideB = new Side(4),
            SideC = new Side(5)
        };

        triangle = (Triangle)ShapeFactory.CreateShape(triangleParameters);
        isRightTriangle = triangle.IsRightTriangle();
        Assert.AreEqual(true, isRightTriangle);
    }
}