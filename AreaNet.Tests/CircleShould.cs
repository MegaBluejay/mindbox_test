using AreaNet.Shapes;

namespace AreaNet.Tests;

[TestFixture]
[TestOf(typeof(Circle))]
public class CircleShould
{
    [TestCase(0, 0, -1)]
    [TestCase(0, 0, -100)]
    [TestCase(100, -200, -1)]
    [TestCase(100, -200, -100)]
    public void NegativeRadius(double x, double y, double radius)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { _ = new Circle(new Point(x, y), radius); });
        Assert.Throws<ArgumentOutOfRangeException>(() => { _ = new Circle(x, y, radius); });
    }
    

    [TestCase(0, 0, 0, 0)]
    [TestCase(0, 0, 1, Math.PI)]
    [TestCase(0, 0, 2, Math.PI * 4)]
    [TestCase(100, -200, 0, 0)]
    [TestCase(100, -200, 1, Math.PI)]
    [TestCase(100, -200, 2, Math.PI * 4)]
    public void Area(double x, double y, double radius, double area)
    {
        Assert.That(new Circle(x, y, radius).Area, Is.EqualTo(area).Within(1e-5));
    }
}