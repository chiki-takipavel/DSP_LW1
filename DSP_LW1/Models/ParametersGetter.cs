using System;

namespace DSP_LW1.Models
{
    public static class ParametersGetter
    {
        public static ParametersModel GetSignal(MainWindow window)
        {
            ParametersModel result = new();
            result.A[0] = Convert.ToDouble(window.tbAmplitude.Text);
            result.F[0] = Convert.ToDouble(window.tbFrequency.Text);
            result.WellRate[0] = window.slDutyCycle.Value;

            return result;
        }

        public static ParametersModel GetPolySignal(MainWindow window)
        {
            ParametersModel result = new();
            result.A[0] = Convert.ToDouble(window.tbAmplitude.Text);
            result.A[1] = Convert.ToDouble(window.tbAmplitude1.Text);
            result.A[2] = Convert.ToDouble(window.tbAmplitude2.Text);
            result.A[3] = Convert.ToDouble(window.tbAmplitude3.Text);
            result.F[0] = Convert.ToDouble(window.tbFrequency.Text);
            result.F[1] = Convert.ToDouble(window.tbFrequency1.Text);
            result.F[2] = Convert.ToDouble(window.tbFrequency2.Text);
            result.F[3] = Convert.ToDouble(window.tbFrequency3.Text);
            result.P[0] = Convert.ToDouble(window.tbPhase.Text);
            result.P[1] = Convert.ToDouble(window.tbPhase1.Text);
            result.P[2] = Convert.ToDouble(window.tbPhase2.Text);
            result.P[3] = Convert.ToDouble(window.tbPhase3.Text);
            result.WellRate[0] = Convert.ToDouble(window.slDutyCycle.Value);
            result.WellRate[1] = Convert.ToDouble(window.slDutyCycle1.Value);
            result.WellRate[2] = Convert.ToDouble(window.slDutyCycle2.Value);
            result.WellRate[3] = Convert.ToDouble(window.slDutyCycle3.Value);

            return result;
        }

        public static ParametersModel GetModulationSignal(MainWindow window)
        {
            ParametersModel result = new();
            result.A[0] = Convert.ToDouble(window.tbAmplitude.Text);
            result.F[0] = Convert.ToDouble(window.tbFrequency.Text);
            result.A[1] = Convert.ToDouble(window.tbModulationAmplitude.Text);
            result.F[1] = Convert.ToDouble(window.tbModulationFrequency.Text);
            result.WellRate[0] = Convert.ToDouble(window.slDutyCycle.Value);
            result.WellRate[1] = Convert.ToDouble(window.slModulationDutyCycle.Value);

            return result;
        }
    }
}
