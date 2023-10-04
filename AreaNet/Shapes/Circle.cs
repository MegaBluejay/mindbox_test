namespace AreaNet.Shapes;

public class Circle: IArea
{
    public Point Center { get; set; }
    public double Radius { get; set; }

    public Circle(Point center, double radius)
    {
        Center = center;

        if (radius < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius));
        }
        
        Radius = radius;
    }

    public Circle(double x, double y, double radius)
        : this(new Point(x, y), radius) { }

    public double Area
        => Math.PI * Math.Pow(Radius, 2);
}