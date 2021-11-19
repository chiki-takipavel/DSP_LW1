using System.Collections.Generic;

namespace DSP_LW1.Signals
{
    public class PoliHarmonicSignal
    {
        public double[] AmplitudeJ { get; private set; }

        public double[] FrequencyJ { get; private set; }

        public double[] PhaseJ { get; private set; }

        public int N { get; private set; }

        public double[] Values { get; private set; }

        public PoliHarmonicSignal(double[] A, double[] F, double[] P, int N, int k, Signal[] signal)
        {
            AmplitudeJ = A;
            FrequencyJ = F;
            PhaseJ = P;
            this.N = N;

            List<double[]> signals = new();
            for (int i = 0; i < k; i++)
            {
                signal[i].Amplitude = A[i];
                signal[i].Frequency = F[i];
                signal[i].Phase = P[i];
                signal[i].N = N;
                signal[i].Generate();
                signals.Add(signal[i].Values);
            }

            Values = new double[N * 10];
            for (int i = 0; i < N * 10; i++)
            {
                Values[i] = 0;

                for (int j = 0; j < k; j++)
                {
                    Values[i] += signals[j][i];
                }
            }
        }
    }
}