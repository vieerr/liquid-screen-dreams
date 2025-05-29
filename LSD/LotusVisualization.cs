using System;
using System.Drawing;
using System.Drawing.Drawing2D;

public static class LotusVisualization
{
    private static float _rotationAngle = 0;
    private static float[] _petalHistory = new float[8];
    
    public static void Draw(Graphics g, Rectangle bounds, float sampleValue)
    {
        int centerX = bounds.Width / 2;
        int centerY = bounds.Height / 2;
        int baseSize = (int)(Math.Min(bounds.Width, bounds.Height) / 3 + sampleValue* 100);
        
        // Update rotation and petal history
        _rotationAngle += sampleValue;
        for (int i = _petalHistory.Length - 1; i > 0; i--)
            _petalHistory[i] = _petalHistory[i - 1];
        _petalHistory[0] = sampleValue;
        
        // Draw the lotus
        DrawLotus(g, centerX, centerY, baseSize, _rotationAngle, _petalHistory);
    }
    
    private static void DrawLotus(Graphics g, int centerX, int centerY, int baseSize, float rotation, float[] petalValues)
    {
        // Configure smooth drawing
        g.SmoothingMode = SmoothingMode.AntiAlias;
        
        // Draw outer petals (layer 1)
        for (int i = 0; i < 8; i++)
        {
            float angle = rotation + i * (float)(Math.PI * 2 / 8);
            float size = baseSize * (1.2f + petalValues[i] * 0.5f);
            DrawPetal(g, centerX, centerY, angle, size, 0.8f, 
                     Color.Purple);
        }
        
        // Draw middle petals (layer 2)
        for (int i = 0; i < 8; i++)
        {
            float angle = rotation * 1.3f + i * (float)(Math.PI * 2 / 8);
            float size = baseSize * (0.8f + petalValues[(i + 2) % 8] * 0.3f);
            DrawPetal(g, centerX, centerY, angle, size, 0.6f, 
                     Color.Violet);
        }
        
        // Draw inner petals (layer 3)
        for (int i = 0; i < 8; i++)
        {
            float angle = rotation * 0.7f + i * (float)(Math.PI * 2 / 8);
            float size = baseSize * (0.5f + petalValues[(i + 4) % 8] * 0.2f);
            DrawPetal(g, centerX, centerY, angle, size, 0.4f, 
                     Color.White);
        }
        
        // Draw center stamen
        float centerSize = baseSize * 0.15f * (1 + petalValues[0] * 0.2f);
        g.FillEllipse(new SolidBrush(Color.Black), 
                     centerX - centerSize, centerY - centerSize, 
                     centerSize * 2, centerSize * 2);
        
        // Add center glow
        using (var glowPath = new GraphicsPath())
        {
            glowPath.AddEllipse(centerX - centerSize * 3, centerY - centerSize * 3, 
                               centerSize * 6, centerSize * 6);
            using (var glowBrush = new PathGradientBrush(glowPath))
            {
                glowBrush.CenterColor = Color.White;
                glowBrush.SurroundColors = new[] { Color.FromArgb(0, 255, 240, 150) };
                g.FillPath(glowBrush, glowPath);
            }
        }
    }
    
    private static void DrawPetal(Graphics g, int centerX, int centerY, float angle, float size, float widthRatio, Color color)
    {
        using (var path = new GraphicsPath())
        {
            // Create petal shape
            float width = size * widthRatio;
            float height = size;
            
            PointF center = new PointF(centerX, centerY);
            PointF tip = new PointF(
                centerX + height * (float)Math.Sin(angle),
                centerY - height * (float)Math.Cos(angle));
            
            PointF left = new PointF(
                centerX + width * 0.5f * (float)Math.Sin(angle - Math.PI/2),
                centerY - width * 0.5f * (float)Math.Cos(angle - Math.PI/2));
            
            PointF right = new PointF(
                centerX + width * 0.5f * (float)Math.Sin(angle + Math.PI/2),
                centerY - width * 0.5f * (float)Math.Cos(angle + Math.PI/2));
            
            // Build curved petal path
            path.AddBezier(center, left, left, tip);
            path.AddBezier(tip, right, right, center);
            
            // Draw with gradient fill
            using (var brush = new LinearGradientBrush(
                new PointF(centerX - size, centerY - size),
                new PointF(centerX + size, centerY + size),
                Color.FromArgb(color.A/2, color),
                color))
            {
                g.FillPath(brush, path);
            }

            // Add petal outline
            using (var pen = new Pen(Color.Black))
            {
                g.DrawPath(pen, path);
            }
        }
    }
}