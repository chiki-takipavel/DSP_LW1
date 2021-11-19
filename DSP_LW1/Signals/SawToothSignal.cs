using System;

namespace DSP_LW1.Signals
{
    public class SawToothSignal : Signal
    {
        public SawToothSignal(double A, double F, int N) : base(A, F, N) { }

        public SawToothSignal(double A, double F, double P, int N) : base(A, F, P, N) { }

        public override double GetValue(int i)
        {
            return -2 * Amplitude / Math.PI * Math.Atan(1 / Math.Tan((Math.PI * Frequency * i / N) + Phase));
        }
    }
}
