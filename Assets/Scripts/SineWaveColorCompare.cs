using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveColorCompare : MonoBehaviour {
    public SineWave Target;
    public Color BaseColor;
    public Color TargetColor;
    public float DistanceFactor;

    private float maxAmplitudeDistance;
    private float maxWaveDistance;

    private SineWave sineWave;

	// Use this for initialization
	void Start () {
        sineWave = GetComponent<SineWave>();
        sineWave.WaveColor = BaseColor;
        maxAmplitudeDistance = sineWave.MaxAmplitude - sineWave.MinAmplitude;
        maxWaveDistance = sineWave.MaxWavelength - sineWave.MinWavelength;
	}
	
	// Update is called once per frame
	void Update () {
        float waveDistance = sineWave.WaveLength - Target.WaveLength;
        float amplitudeDistance = sineWave.Amplitude - Target.Amplitude;

        float t = Mathf.Abs((waveDistance / maxWaveDistance + amplitudeDistance / maxAmplitudeDistance) * DistanceFactor);

        sineWave.WaveColor = Color.Lerp(TargetColor, BaseColor, t);
	}
}
