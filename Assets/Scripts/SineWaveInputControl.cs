using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveInputControl : MonoBehaviour {
    public string VerticalAxis;
    public string HorizontalAxis;

    public float VerticalSensitivity = 0.2f;
    public float HorizontalSensitivity = 0.2f;
    private SineWave sineWave;

    private void Start()
    {
        sineWave = GetComponent<SineWave>();

        var targetSineWave = GetComponent<SineWaveColorCompare>().Target;
        sineWave.WaveLength = targetSineWave.WaveLength;
        sineWave.Amplitude = targetSineWave.Amplitude;
    }

	// Update is called once per frame
	private void Update () {
        if (GameManager.Instance.HasGameEnded) return;

        if (!sineWave) return;

        var verticalInput = VerticalAxis != "" ? Input.GetAxis(VerticalAxis) : 0f;
        var horizontalInput = HorizontalAxis != "" ? Input.GetAxis(HorizontalAxis) : 0f;

        sineWave.Amplitude += verticalInput * VerticalSensitivity;
        sineWave.WaveLength += horizontalInput * HorizontalSensitivity;
    }
}
