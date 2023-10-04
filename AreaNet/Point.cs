namespace AreaNet;

public record struct Point(double X, double Y)
{
    public static Point operator +(Point p1, Point p2)
        => new(p1.X + p2.X, p1.Y + p2.Y);

    public static Point operator -(Point p1, Point p2) 
        => new(p1.X - p2.X, p1.Y - p2.Y);

    public double NormSq => Math.Pow(X, 2) + Math.Pow(Y, 2);
}