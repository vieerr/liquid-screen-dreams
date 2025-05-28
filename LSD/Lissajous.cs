using System;
using System.Drawing;

public static class Lissajous
{
    public static void DrawLissajous(Graphics g, Pen pen, Rectangle bounds,
                                    double frequencyRatio, double phaseShift,
                                    int points = 1000, int rotation = 0)
    {
        PointF[] pointsArray = CalculateLissajousPoints(bounds, frequencyRatio, phaseShift, points, rotation);
        g.DrawLines(pen, pointsArray);
    }

    public static void FillLissajous(Graphics g, Brush brush, Rectangle bounds,
                                    double frequencyRatio, double phaseShift,
                                    int points = 1000, int rotation = 0)
    {
        PointF[] pointsArray = CalculateLissajousPoints(bounds, frequencyRatio, phaseShift, points, rotation);
        g.FillClosedCurve(brush, pointsArray);
    }

    private static PointF[] CalculateLissajousPoints(Rectangle bounds,
                                                   double frequencyRatio,
                                                   double phaseShift,
                                                   int points, int rotation = 0)
    {
        PointF[] pointsArray = new PointF[points];
        float centerX = bounds.X + bounds.Width / 2f;
        float centerY = bounds.Y + bounds.Height / 2f;
        float scaleX = bounds.Width / 2f * 0.9f; // 90% of half width to keep within bounds
        float scaleY = bounds.Height / 2f * 0.9f; // 90% of half height

        for (int i = 0; i < points; i++)
        {
            double t = 2 * Math.PI * i / points;
            float x = centerX + (float)(scaleX * Math.Sin(t + phaseShift));
            float y = centerY + (float)(scaleY * Math.Sin(frequencyRatio * t));
            pointsArray[i] = new PointF(x, y);
        }

        if(rotation != 0 )
        {
            for (int i = 1; i < points; i++)
            {
                pointsArray[i] = new PointF(
                    (float)(pointsArray[i].X * Math.Cos(rotation) - pointsArray[i].Y * Math.Sin(rotation)),
                    (float)(pointsArray[i].X * Math.Sin(rotation) + pointsArray[i].Y * Math.Cos(rotation))
                );
            }

        }

        return pointsArray;
    }
}