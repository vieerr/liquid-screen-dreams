using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private string _currentSongTitle = "";
        private int _marqueePosition = 0;
        private bool _isPlaying = false;
        public Form1()
        {
            InitializeComponent();
            _renderer = new GraphRenderer(pictureBoxGraph);
            SetupControls();
        }

        private void SetupControls()
        {
            // Configurar botones
            btnPlay.Enabled = false;
            btnPause.Enabled = false;
            btnStop.Enabled = false;
            btnNext.Enabled = false;
            btnPrevious.Enabled = false;

            // Configurar barra de volumen
            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 100;
            trackBarVolume.Value = 50; // Volumen medio por defecto
            lblVolume.Text = "Volumen: 50%";

            // Configurar timers
            timerMarquee.Interval = 100; // Intervalo para el efecto marquesina
            timerProgress.Interval = 500; // Actualizar progreso cada 500ms
        }

        private void btnSelectPlay_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "MP3 Files|*.mp3";
                dlg.Title = "Seleccionar y reproducir MP3";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PlayNewFile(dlg.FileName);
                }
            }
        }
        private void PlayNewFile(string filePath)
        {
            _player?.Dispose();
            _player = new AudioAnalyzerPlayer(filePath);

            // Configurar eventos
            _player.OnNewRmsSample += sample =>
            {
                if (InvokeRequired)
                    BeginInvoke(new Action(() => _renderer.AddSample(sample)));
                else
                    _renderer.AddSample(sample);
            };

            // Configurar información de la canción
            _currentSongTitle = System.IO.Path.GetFileNameWithoutExtension(filePath);
            UpdateSongTitleDisplay();

            // Configurar barra de progreso
            //progressBarSong.Maximum = (int)_player.TotalTime.TotalSeconds;
            progressBarSong.Value = 0;

            // Actualizar tiempos
            //lblTotalTime.Text = _player.TotalTime.ToString(@"mm\:ss");
            lblCurrentTime.Text = TimeSpan.Zero.ToString(@"mm\:ss");

            // Habilitar controles
            btnPlay.Enabled = true;
            btnPause.Enabled = true;
            btnStop.Enabled = true;

            // Iniciar reproducción
            _player.Play();
            _isPlaying = true;

            // Iniciar timers
            timerProgress.Start();
            timerMarquee.Start();
        }

        private void UpdateSongTitleDisplay()
        {
                lblSongTitle.Text = _currentSongTitle.Substring(_marqueePosition) + " " + _currentSongTitle.Substring(0, _marqueePosition);
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _player?.Dispose();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
                _player.Stop();
                _isPlaying = false;
                timerProgress.Stop();
                timerMarquee.Stop();
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
                _player.Play();
                _isPlaying = true;
                timerProgress.Start();
                timerMarquee.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _player.Quit();
            _player.Dispose();
            _renderer.Clear();
            _isPlaying = false;
            timerProgress.Stop();
            timerMarquee.Stop();
            progressBarSong.Value = 0;
            lblCurrentTime.Text = TimeSpan.Zero.ToString(@"mm\:ss");
        }
        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            if (_player != null)
            {
                _player.SetVolume(trackBarVolume.Value / 100f);
                lblVolume.Text = $"Volumen: {trackBarVolume.Value}%";
            }
        }
        private void timerMarquee_Tick(object sender, EventArgs e)
        {
                _marqueePosition++;
                if (_marqueePosition >= _currentSongTitle.Length)
                    _marqueePosition = 0;

                UpdateSongTitleDisplay();
        }
        private void timerProgress_Tick(object sender, EventArgs e)
        {
                var currentTime = _player.CurrentTime;
                progressBarSong.Value = (int)currentTime.TotalSeconds;
                lblCurrentTime.Text = currentTime.ToString(@"mm\:ss");
        }

        private void progressBarSong_MouseDown(object sender, MouseEventArgs e)
        {
            if (_player != null)
            {
                // TOFIX
                double percent = (double)e.X / progressBarSong.Width;
                TimeSpan newTime = TimeSpan.FromSeconds(percent * _player.TotalTime.TotalSeconds);

                _player.Seek(newTime);
                progressBarSong.Value = (int)newTime.TotalSeconds;
                lblCurrentTime.Text = newTime.ToString(@"mm\:ss");
            }
        }
    }
}
