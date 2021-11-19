using System;

namespace DSP_LW1.Signals
{
    public class SinusoidSignal : Signal
    {
        public SinusoidSignal(double A, double F, int N) : base(A, F, N) { }

        public SinusoidSignal(double A, double F, double P, int N) : base(A, F, P, N) { }

        public override double GetValue(int i)
        {
            return Amplitude * Math.Sin((2 * Math.PI * Frequency * i / N) + Phase);
        }
    }
}