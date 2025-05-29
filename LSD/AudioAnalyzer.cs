using System;
using System.Collections.Generic;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.Threading;

namespace LSD
{
    public class AudioAnalyzerPlayer : IDisposable
    {
        private readonly WaveOutEvent _output;
        private readonly AudioFileReader _reader;
        private readonly int _blockMilliseconds;
        private readonly float[] _buffer;
        private readonly int _blockSize;
        private Thread _analyzeThread;
        private volatile bool _running;

        public event Action<float> OnNewRmsSample;

        public AudioAnalyzerPlayer(string filePath, int blockMilliseconds = 50)
        {
            _reader = new AudioFileReader(filePath);
            _output = new WaveOutEvent();
            _output.Init(_reader);
            _blockMilliseconds = blockMilliseconds;
            _blockSize = (_reader.WaveFormat.AverageBytesPerSecond * blockMilliseconds) / 3000;
            _buffer = new float[_blockSize / sizeof(float)];
            _analyzeThread = new Thread(AnalyzeLoop) { IsBackground = true };
        }

        public void SetVolume(float volume)
        {
            if (volume < 0 || volume > 1)
                throw new ArgumentOutOfRangeException(nameof(volume), "Volume must be between 0 and 1.");
            _output.Volume = volume;
        }

        public TimeSpan CurrentTime
        {
            get => _reader.CurrentTime;
            set => _reader.CurrentTime = value;
        }
        public TimeSpan TotalTime => _reader.TotalTime;

        public void Play()
        {
            _running = true;
            _output.Play();
            if(_analyzeThread.ThreadState == ThreadState.Unstarted)
            {
                _analyzeThread.Start();
            }
            else if (!_analyzeThread.IsAlive)
            {
                _analyzeThread = new Thread(AnalyzeLoop) { IsBackground = true };
                _analyzeThread.Start();
            }
        }

        public void Stop()
        {
            _running = false;
            _output.Stop();
            if (_analyzeThread.IsAlive)
            {
                _analyzeThread.Join();
            }
        }

        public void Quit()
        {
            Stop();
            _output.Dispose();
            _reader.Dispose();
        }
        public void Seek(TimeSpan position)
        {
            _reader.CurrentTime = position;
        }


        private void AnalyzeLoop()
        {
            while (_running)
            {
                int read = _reader.Read(_buffer, 0, _buffer.Length);
                if (read == 0) break;

                double sumSq = 0;
                int samples = read;
                for (int i = 0; i < read; i++)
                    sumSq += _buffer[i] * _buffer[i];

                float rms = (float)Math.Sqrt(sumSq / samples);
                OnNewRmsSample?.Invoke(rms);

                Thread.Sleep(_blockMilliseconds);
            }
            _running = false;
        }

        public void Dispose()
        {
            Stop();
            _output.Dispose();
            _reader.Dispose();
        }
    }
}
