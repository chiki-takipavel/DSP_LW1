using NAudio.Wave;
using System;
using System.Collections.Generic;

namespace DSP_LW1.Streams
{
    public class MyWaveStream : ISampleProvider
    {
        public WaveFormat WaveFormat { get; set; }
        public List<float> Samples { get; set; }

        private int offset;

        public MyWaveStream(WaveFormat waveFormat, List<float> samples)
        {
            WaveFormat = waveFormat;
            Samples = samples;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            count = Math.Min(count, Samples.Count - this.offset);
            for (int i = 0; i < count; i++)
            {
                buffer[offset + i] = Samples[this.offset + i];
            }

            this.offset += count;
            return count;
        }
    }
}
