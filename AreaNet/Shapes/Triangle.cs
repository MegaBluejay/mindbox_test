namespace AreaNet.Shapes;

public class Triangle: IArea
{
    private readonly Point[] _points;

    public Point GetPoint(int index)
    {
        if (index is >= 0 and < 3)
        {
            return _points[index];
        }

        throw new ArgumentOutOfRangeException(nameof(index));
    }

    public Triangle(Point p0, Point p1, Point p2)
    {
        _points = new[] { p0, p1, p2 };
    }
    
    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        : this(new Point(x1, y1), new Point(x2, y2), new Point(x3, y3)) {}

    public Triangle(Point[] points)
    {
        if (points.Length != 3)
        {
            throw new ArgumentException(
                $"Triangle must be composed of exactly 3 points, {points.Length} given",
                nameof(points));
        }

        _points = points;
    }

    public double Area
    {
        get
        {
            var sidesSq = _points.Zip(_points.Skip(1).Append(_points[0])).Select(ps =>
            {
                var (p1, p2) = ps;
                return (p2 - p1).NormSq;
            }).ToArray();
            return Math.Sqrt(Math.Pow(sidesSq.Sum(), 2) - 2 * sidesSq.Select(s => Math.Pow(s, 2)).Sum()) / 4;
        }
    }
}