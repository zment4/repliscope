using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnKnobWithSineWave : MonoBehaviour {
    public SineWave SineWave;

    public enum WithAttributeEnum { Amplitude, Wavelength };
    public WithAttributeEnum WithAttribute;

    public float MinZRot = -120;
    public float MaxZRot = 120;

	// Update is called once per frame
	void Update () {
        if (!SineWave) return;

        var t = 0f;

        if (WithAttribute == WithAttributeEnum.Amplitude)
        {
            t = (SineWave.Amplitude - SineWave.MinAmplitude) / (SineWave.MaxAmplitude - SineWave.MinAmplitude);
        }
        else if (WithAttribute == WithAttributeEnum.Wavelength)
        {
            t = (SineWave.WaveLength - SineWave.MinWavelength) / (SineWave.MaxWavelength - SineWave.MinWavelength);
        }

        transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, MinZRot + t * (MaxZRot - MinZRot)));
	}
}
