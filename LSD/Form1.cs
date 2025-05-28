using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSD
{
    public partial class Form1 : Form
    {
        private AudioAnalyzerPlayer _player;
        private GraphRenderer _renderer;
        public Form1()
        {
            InitializeComponent();
            _renderer = new GraphRenderer(pictureBoxGraph, maxSamples: pictureBoxGraph.Width);
        }
        private void btnSelectPlay_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "MP3 Files|*.mp3";
                dlg.Title = "Seleccionar y reproducir MP3";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _player?.Dispose();
                    _player = new AudioAnalyzerPlayer(dlg.FileName);
                    _player.OnNewRmsSample += sample =>
                    {
                        if (InvokeRequired)
                            BeginInvoke(new Action(() => _renderer.AddSample(sample)));
                        else
                            _renderer.AddSample(sample);
                    };
                    _player.Play();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _player?.Dispose();
        }
    }
}
