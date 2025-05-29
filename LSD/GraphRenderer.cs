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

        public GraphRenderer(PictureBox pictureBox)
        {
            _pictureBox = pictureBox;
        }

        public void AddSample(float sample)
        {
            Render(sample);
        }

        public void Clear()
        {
            if (_pictureBox.Image != null)
            {
                _pictureBox.Image.Dispose();
                _pictureBox.Image = null;
            }
        }
        private void Render(float sample)
        {

            int w = _pictureBox.Width;
            int h = _pictureBox.Height;
            var bmp = new Bitmap(w, h);
            float centerX = w / 2f;
            float centerY = h / 2f;
            Pen redBig = new Pen(Color.Red, 7f); 
            Pen shyRed = new Pen(Color.IndianRed, 7f);
            Pen grayBig = new Pen(Color.Gray, 4f);
            Pen bigBlack = new Pen(Color.Black, 4f);
            Pen greenBig = new Pen(Color.DarkGreen, 4f);
            Pen violetBig = new Pen(Color.Violet, 4f);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);

                float randomSF = 1000f + (float)new Random().NextDouble() * 0.5f; // Random scale factor between 0.5 and 1.0


                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                if(sample >= 0.15f)
                {
                    g.DrawEllipse(redBig, w / 2 - sample * 1000, h / 2 - sample * 1000, sample * 2000, sample * 2000);
                    //Lissajous.DrawLissajous(g, grayBig, new Rectangle(-50, -50, w + 100, h + 100), sample * randomSF, sample * randomSF / 2, 100);
                    Lissajous.FillLissajous(g, Brushes.White, new Rectangle(-50, -50, w + 100, h + 100), sample * randomSF, sample * randomSF, 100);

                }
                if (sample >= 0.20f)
                {
                    g.Clear(Color.White);
                    g.DrawEllipse(violetBig, w / 2 - sample * 1500, h / 2 - sample * 1500, sample * 3000, sample * 3000);
                    g.DrawEllipse(shyRed, w / 2 - sample * 1250, h / 2 - sample * 1250, sample * 2500, sample * 2500);
                    //Lissajous.DrawLissajous(g, bigBlack, new Rectangle(-50, -50, w + 100, h + 100), sample * randomSF / 2, sample * randomSF / 3, 100);
                    Lissajous.FillLissajous(g, Brushes.Black, new Rectangle(-50, -50, w + 100, h + 100), sample * randomSF / 2, sample * randomSF / 3, 100);
                }
                if (sample >= 0.25f)
                {
                    g.Clear(Color.Black);
                    g.DrawEllipse(greenBig, w / 2 - sample * 2000, h / 2 - sample * 2000, sample * 4000, sample * 4000);
                    g.DrawEllipse(shyRed, w / 2 - sample * 1750, h / 2 - sample * 1750, sample * 3500, sample * 3500);
                    //Lissajous.DrawLissajous(g, bigBlack, new Rectangle(-50, -50, w + 100, h + 100), sample * randomSF / 3, sample * randomSF / 4, 100);
                    Lissajous.FillLissajous(g, Brushes.Black, new Rectangle(-50, -50, w + 100, h + 100), sample * randomSF / 3, sample * randomSF / 4, 100);
                }
                g.DrawEllipse(violetBig, w / 2 - sample * 250, h / 2 - sample * 250, sample * 500, sample * 500);

            }
            _pictureBox.Image?.Dispose();
            _pictureBox.Image = bmp;
        }
    }   
}
