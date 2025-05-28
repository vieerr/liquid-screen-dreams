using System;
using System.Drawing;
using System.Collections.Generic;

public static class Oscilloscope
{
    private static Queue<float> _sampleBuffer = new Queue<float>();
    private static int _bufferSize = 1000;
    private static float _timeBase = 1.0f;
    private static float _voltageScale = 1.0f;
    private static Color _gridColor = Color.FromArgb(60, 60, 60);
    private static Color _traceColor = Color.Lime;

    public static void Initialize(int bufferSize = 1000)
    {
        _bufferSize = bufferSize;
        _sampleBuffer.Clear();
        // Pre-fill with zeros
        for (int i = 0; i < _bufferSize; i++)
        {
            _sampleBuffer.Enqueue(0);
        }
    }

    public static void AddSample(float sample)
    {
        _sampleBuffer.Dequeue();
        _sampleBuffer.Enqueue(sample);
    }

    public static void Draw(Graphics g, Rectangle bounds)
    {
        if (_sampleBuffer.Count == 0) return;

        using (var gridPen = new Pen(_gridColor, 1f))
        using (var tracePen = new Pen(_traceColor, 1.5f))
        using (var centerPen = new Pen(_gridColor, 1.5f))
        {
            // Draw grid
            DrawGrid(g, bounds, gridPen, centerPen);

            // Draw waveform
            DrawWaveform(g, bounds, tracePen);
        }
    }

    private static void DrawGrid(Graphics g, Rectangle bounds, Pen gridPen, Pen centerPen)
    {
        const int divisionsX = 10;
        const int divisionsY = 8;

        // Vertical divisions (time)
        float divWidth = bounds.Width / (float)divisionsX;
        for (int i = 0; i <= divisionsX; i++)
        {
            float x = bounds.Left + i * divWidth;
            g.DrawLine(gridPen, x, bounds.Top, x, bounds.Bottom);
        }

        // Horizontal divisions (voltage)
        float divHeight = bounds.Height / (float)divisionsY;
        for (int i = 0; i <= divisionsY; i++)
        {
            float y = bounds.Top + i * divHeight;
            g.DrawLine(gridPen, bounds.Left, y, bounds.Right, y);
        }

        // Draw center lines
        float centerY = bounds.Top + bounds.Height / 2f;
        g.DrawLine(centerPen, bounds.Left, centerY, bounds.Right, centerY);
    }

    private static void DrawWaveform(Graphics g, Rectangle bounds, Pen tracePen)
    {
        var samples = _sampleBuffer.ToArray();
        var points = new PointF[samples.Length];
        float centerY = bounds.Top + bounds.Height / 2f;
        float pixelsPerVolt = bounds.Height / (_voltageScale * 8); // 8 divisions

        for (int i = 0; i < samples.Length; i++)
        {
            float x = bounds.Left + (i * bounds.Width / (float)samples.Length);
            float y = centerY - (samples[i] * pixelsPerVolt);
            points[i] = new PointF(x, y);
        }

        g.DrawLines(tracePen, points);
    }

    // Configuration properties
    public static float TimeBase
    {
        get => _timeBase;
        set => _timeBase = value;
    }

    public static float VoltageScale
    {
        get => _voltageScale;
        set => _voltageScale = value;
    }

    public static Color GridColor
    {
        get => _gridColor;
        set => _gridColor = value;
    }

    public static Color TraceColor
    {
        get => _traceColor;
        set => _traceColor = value;
    }
}