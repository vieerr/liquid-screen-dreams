using System;
using System.Drawing;
using System.Drawing.Drawing2D;

public static class StarOfDavidVisualizer
{
    public static void Draw(Graphics g, Rectangle bounds, float sampleValue)
    {
        int centerX = bounds.Width / 2;
        int centerY = bounds.Height / 2;

        // Base size responds to audio sample (20% to 100% of available space)  
        float sizeScale = 0.2f + sampleValue * 3f;
        int size = (int)(Math.Min(bounds.Width, bounds.Height) * 0.4f * sizeScale);

        // Create the star path  
        using (var starPath = CreateStarPath(centerX, centerY, size))
        {
            // Gradient fill from blue to gold  
            using (var brush = new LinearGradientBrush(bounds, Color.Blue, Color.Gold, LinearGradientMode.ForwardDiagonal))
            {
                g.FillPath(brush, starPath);
            }

            // Glowing outline  
            using (var pen = new Pen(Color.FromArgb(150, 200, 230, 255), 3f))
            {
                g.DrawPath(pen, starPath);
            }
        }

        // Add pulsing center glow during loud moments  
        if (sampleValue > 0.7f)
        {
            int glowSize = (int)(size * 0.3f * sampleValue);
            using (var glowBrush = new SolidBrush(Color.FromArgb(
                (int)(50 * sampleValue),
                Color.Cyan)))
            {
                g.FillEllipse(glowBrush,
                    centerX - glowSize / 2,
                    centerY - glowSize / 2,
                    glowSize, glowSize);
            }
        }
    }

    private static GraphicsPath CreateStarPath(int centerX, int centerY, int size)
    {
        var path = new GraphicsPath();

        // Calculate the six points of the star  
        PointF[] points = new PointF[6];
        for (int i = 0; i < 6; i++)
        {
            double angle = Math.PI / 3 * i - Math.PI / 2; // Offset to make one point at top  
            points[i] = new PointF(
                centerX + size * (float)Math.Cos(angle),
                centerY + size * (float)Math.Sin(angle));
        }

        // Create two overlapping triangles  
        path.AddPolygon(new[] { points[0], points[2], points[4] }); // Upward triangle  
        path.AddPolygon(new[] { points[1], points[3], points[5] }); // Downward triangle  

        return path;
    }
}
