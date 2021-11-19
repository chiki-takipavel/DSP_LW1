using System;

namespace DSP_LW1.Signals
{
    public static class Modulator
    {
        public static double[] AmplitudeModulation(Signal signal1, Signal signal2)
        {
            signal1.Generate();
            signal2.Generate();

            if (signal1.Values.Length != signal2.Values.Length)
            {
                throw new Exception("Сигналы должны иметь одинаковую длину");
            }

            double[] values = new double[signal1.Values.Length];
            for (int i = 0; i < signal1.Values.Length; i++)
            {
                values[i] = signal1.Values[i] * signal2.Values[i];
            }
            return values;
        }

        public static double[] FrequencyModulation(Signal signal1, Signal signal2)
        {
            signal2.Generate();
            signal1.Values = new double[signal2.Values.Length];
            signal1.Phase = 0;
            for (int i = 0; i < signal2.Values.Length; i++)
            {
                signal1.Values[i] = signal1.GetValue(1);
                signal1.Phase += signal1.Frequency * 2 * Math.PI * (1d / signal1.N) * (1 + signal2.Values[i]);
            }
            return signal1.Values;
        }
    }
}
