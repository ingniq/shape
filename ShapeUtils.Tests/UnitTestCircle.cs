using System.ComponentModel.DataAnnotations;
using Ingniq.ShapeUtils.GeometricMeasurements;
using Ingniq.ShapeUtils.Shapes;

namespace Ingniq.ShapeUtils.Tests;

[TestClass]
public class UnitTestCircle
{
    [TestMethod]
    public void TestCircleMethodWithInt()
    {
        Shape circle;
        double circleArea;
        CircleParameters circleParameters = new();

        circleParameters.Radius = new Radius(0);
        circle = ShapeFactory.CreateShape(circleParameters);
        circleArea = circle.CalculateArea();
        Assert.AreEqual(0, circleArea);

        circleParameters.Radius = new Radius(1);
        circle = ShapeFactory.CreateShape(circleParameters);
        circleArea = circle.CalculateArea();
        Assert.AreEqual(Math.PI, circleArea);

        circleParameters.Radius = new Radius(10);
        circle = ShapeFactory.CreateShape(circleParameters);
        circleArea = circle.CalculateArea();
        Assert.AreEqual(314.15926535897932, circleArea);
    }

    [TestMethod]
    public void TestCircleMethodWithDouble()
    {
        Shape circle;
        double circleArea;
        CircleParameters circleParameters = new();

        circleParameters.Radius = new Radius(0.1);
        circle = ShapeFactory.CreateShape(circleParameters);
        circleArea = circle.CalculateArea();
        Assert.AreEqual(0.031415926535897934, circleArea);

        circleParameters.Radius = new Radius(10.5);
        circle = ShapeFactory.CreateShape(circleParameters);
        circleArea = circle.CalculateArea();
        Assert.AreEqual(346.3605900582747, circleArea);

        circleParameters.Radius = new Radius(4.2678378161541536E+153);
        circle = ShapeFactory.CreateShape(circleParameters);
        circleArea = circle.CalculateArea();
        Assert.AreEqual(5.722234971514055E+307, circleArea);
    }

    [TestMethod]
    public void TestCircleMethodExceptions()
    {
        Action act;
        Shape circle;
        ValidationException validationException;
        CircleParameters circleParameters = new();

        circleParameters.Radius = new Radius(-1);
        act = () => ShapeFactory.CreateShape(circleParameters);
        validationException = Assert.ThrowsException<ValidationException>(act);
        Assert.AreEqual("Radius: only positive number allowed.", validationException.Message);

        circleParameters.Radius = new Radius(double.MaxValue);
        circle = ShapeFactory.CreateShape(circleParameters);
        act = () => circle.CalculateArea();

        OverflowException overflowException = Assert.ThrowsException<OverflowException>(act);
        Assert.AreEqual("Arithmetic operation resulted in an overflow.", overflowException.Message);
    }
}