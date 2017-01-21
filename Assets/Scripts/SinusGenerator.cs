using UnityEngine;
using System;  // Needed for Math

public class SinusGenerator : MonoBehaviour
{
    public SineWave SineWave;
    public SineWaveColorCompare SineWaveColorCompare;
    public float DistanceScale = 440;
    public bool PhaseShift = false;
    public enum MonoModeEnum { Right, Left, Stereo };
    public MonoModeEnum MonoMode;

    // un-optimized version
    public double frequency = 440;
    public double gain = 0.05;

    private double increment;
    private double phase;
    private double sampling_frequency = 48000;

    void OnAudioFilterRead(float[] data, int channels)
    {
        var waveLenT = SineWave ? (SineWave.WaveLength - SineWave.MinWavelength) / (SineWave.MaxWavelength - SineWave.MinWavelength) : 1f;

        // update increment in case frequency has changed
        increment = (frequency + waveLenT * DistanceScale) * 2 * Math.PI / sampling_frequency;
        for (var i = 0; i < data.Length; i = i + channels)
        {
            phase = phase + increment;

            var amplitudeT = SineWave ? (SineWave.Amplitude - SineWave.MinAmplitude) / (SineWave.MaxAmplitude - SineWave.MinAmplitude) : 1f;
            // this is where we copy audio data to make them “available” to Unity
            float audioData = (float)(gain * amplitudeT * Math.Sin(phase * (PhaseShift ? -1f : 1f)));
            // if we have stereo, we copy the mono data to each channel
            if (channels == 2)
            {
                if (MonoMode == MonoModeEnum.Left || MonoMode == MonoModeEnum.Stereo)
                {
                    data[i] = (GameManager.HasInstance && GameManager.Instance.HasGameEnded) ? 0f : audioData;
                }

                if (MonoMode == MonoModeEnum.Right || MonoMode == MonoModeEnum.Stereo)
                {
                    data[i + 1] = (GameManager.HasInstance && GameManager.Instance.HasGameEnded) ? 0f : audioData;
                }
            }
            if (phase > 2 * Math.PI) phase = 0;
        }
    }

    private void Update()
    {
        if (SineWaveColorCompare)
            frequency = 440 + SineWaveColorCompare.DistanceNormalized * DistanceScale;
    }
}

