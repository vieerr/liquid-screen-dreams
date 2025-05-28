using System;
using System.Collections.Generic;
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
            if (_samples.Count >= _maxSamples)
                _samples.Dequeue();
            _samples.Enqueue(sample);
            Render();
        }

        private void Render()
        {
            int w = _pictureBox.Width;
            int h = _pictureBox.Height;
            var bmp = new Bitmap(w, h);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);
                if (_samples.Count < 2) { _pictureBox.Image = bmp; return; }

                float max = 0;
                foreach (var v in _samples) if (v > max) max = v;
                if (max <= 0) max = 1;

                PointF[] points = new PointF[_samples.Count];
                int i = 0;
                foreach (var v in _samples)
                {
                    float x = (float)i / (_maxSamples - 1) * w;
                    float y = h - (v / max) * h;
                    points[i++] = new PointF(x, y);
                }
                g.DrawLines(Pens.Lime, points);
            }
            _pictureBox.Image?.Dispose();
            _pictureBox.Image = bmp;
        }
    }   
}
