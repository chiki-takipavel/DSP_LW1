using DSP_LW1.Models;
using DSP_LW1.Signals;
using DSP_LW1.Streams;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows;

namespace DSP_LW1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private delegate Signal GetSignal(ParametersModel model, int index = 0);

        private readonly List<GetSignal> getSignals = new()
        {
            SignalCreator.GetSinusoid,
            SignalCreator.GetPulse,
            SignalCreator.GetTriangle,
            SignalCreator.GetSawTooth,
            SignalCreator.GetNoise
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayClick(object sender, RoutedEventArgs e)
        {
            List<float> bytes = new();
            ParametersModel model;
            if (rbSignal.IsChecked is true)
            {
                model = ParametersGetter.GetSignal(this);
            }
            else if (rbPolySignal.IsChecked is true)
            {
                model = ParametersGetter.GetPolySignal(this);
            }
            else
            {
                model = ParametersGetter.GetModulationSignal(this);
            }

            model.N = 44100;

            List<double> values = GetValues(model).ToList();
            bytes.AddRange(values.Select(value => (float)value));

            PlaySound(bytes);
        }

        private static void PlaySound(List<float> samples)
        {
            ushort numChannels = 1;
            int sampleRate = 44100;

            WaveFormat waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, numChannels);
            ISampleProvider stream = new MyWaveStream(waveFormat, samples);
            WaveFileWriter.CreateWaveFile16("Result.wav", stream);

            SoundPlayer player = new("Result.wav");
            player.Play();
        }

        private double[] GetValues(ParametersModel model)
        {
            if (rbSignal.IsChecked is true)
            {
                Signal signal = getSignals[cmbSignalType.SelectedIndex](model, 0);
                signal.Generate();
                return signal.Values;
            }

            if (rbPolySignal.IsChecked is true)
            {
                List<Signal> signals = new()
                {
                    getSignals[cmbSignalType.SelectedIndex](model, 0),
                    getSignals[cmbSignalType1.SelectedIndex](model, 1),
                    getSignals[cmbSignalType2.SelectedIndex](model, 2),
                    getSignals[cmbSignalType3.SelectedIndex](model, 3),
                };
                PoliHarmonicSignal signal = new(model.A, model.F, model.P, model.N, 4, signals.ToArray());
                return signal.Values;
            }

            if (rbModulationSignal.IsChecked is true)
            {
                Signal signal1 = getSignals[cmbSignalType.SelectedIndex](model, 0);
                Signal signal2 = getSignals[cmbModulationSignalType.SelectedIndex](model, 1);

                if (cmbModulationType.SelectedIndex is 0)
                {
                    List<double> values = Modulator.AmplitudeModulation(signal1, signal2).ToList();
                    return values.ToArray();
                }

                if (cmbModulationType.SelectedIndex is 1)
                {
                    List<double> values = Modulator.FrequencyModulation(signal1, signal2).ToList();
                    return values.ToArray();
                }
            }

            return Array.Empty<double>();
        }
    }
}
