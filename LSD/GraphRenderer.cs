using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LSD
{
    public class GraphRenderer
    {
        private readonly PictureBox _pictureBox;
        private readonly Queue<float> _samples;
        private readonly int _maxSamples;

        public GraphRenderer(PictureBox pictureBox, int maxSamples = 200)
        {
            _pictureBox = pictureBox;
            _maxSamples = maxSamples;
            _samples = new Queue<float>(maxSamples);
        }

        public void AddSample(float sample)
        {
            Trace.WriteLine($"New sample: {sample}");
            //if (_samples.Count >= _maxSamples)
            //    _samples.Dequeue();
            //_samples.Enqueue(sample);
            Render(sample);
        }

        private void Render(float sample)
        {
            int w = _pictureBox.Width;
            int h = _pictureBox.Height;
            var bmp = new Bitmap(w, h);
            float centerX = w / 2f;
            float centerY = h / 2f;
            Pen redBig = new Pen(Color.Red, 7f);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);

                float randomSF = 1000f + (float)new Random().NextDouble() * 0.5f; // Random scale factor between 0.5 and 1.0


                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                float arcDiameter = sample * randomSF;
                float arcX = centerX - arcDiameter / 2f;
                float arcY = centerY - arcDiameter / 2f;
                g.DrawArc(redBig, arcX, arcY, arcDiameter, arcDiameter, 0, 360);
                Lissajous.DrawLissajous(g, Pens.White, new Rectangle(-50, -50, w + 100, h + 100), sample * randomSF, sample * randomSF / 2, 200);
                Lissajous.FillLissajous(g, Brushes.White, new Rectangle(-50, -50, w + 100, h + 100), sample * randomSF/2, sample * randomSF, 200);
            }
            _pictureBox.Image?.Dispose();
            _pictureBox.Image = bmp;
        }
    }   
}
