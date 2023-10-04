using AreaNet.Shapes;

namespace AreaNet.Tests;

[TestFixture]
public class TriangleShould
{
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(4)]
    [TestCase(100)]
    public void InvalidPointNumber(int n)
    {
        var points = Enumerable.Repeat(new Point(0, 0), n).ToArray();
        Assert.Throws<ArgumentException>(() => { _ = new Triangle(points); });
    }

    [TestCase(0, 0, 0, 1, 1, 0, 0.5)]
    [TestCase(0, 0, 1, 1, 2, 0, 1)]
    [TestCase(0, 0, -1, 0, 0, -1, 0.5)]
    [TestCase(0, 0, -2, 0, 0, -1, 1)]
    public void Area(double x1, double y1, double x2, double y2, double x3, double y3, double area)
    {
        Assert.That(new Triangle(x1, y1, x2, y2, x3, y3).Area, Is.EqualTo(area).Within(1e-5));
    }
}