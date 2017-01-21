using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveWanderer : MonoBehaviour {
    public float Speed = 1f;

    private Vector2 wanderDirection;
    private Vector2 wanderTarget;
    private Vector2 wanderPosition;

    private SineWave sineWave;
            
	// Use this for initialization
	void Awake () {
        sineWave = GetComponent<SineWave>();
        sineWave.Amplitude = UnityEngine.Random.Range(sineWave.MinAmplitude, sineWave.MaxAmplitude);
        sineWave.WaveLength = UnityEngine.Random.Range(sineWave.MinWavelength, sineWave.MaxWavelength);

        wanderTarget = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        wanderPosition = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        wanderDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)); ;
	}
	
	// Update is called once per frame
	void Update () {
        var newDir = wanderTarget - wanderPosition;
        wanderDirection = Vector3.Lerp(wanderDirection, newDir, Speed * Time.deltaTime);

        wanderPosition += wanderDirection.normalized * Time.deltaTime * Speed;

        if ((wanderPosition - wanderTarget).magnitude < 0.1f)
        {
            wanderTarget = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        }

        var sineWaveAmplitudeHalf = (sineWave.MaxAmplitude - sineWave.MinAmplitude) / 2f;
        sineWave.Amplitude = (sineWave.MinAmplitude + sineWaveAmplitudeHalf) + wanderDirection.x * sineWaveAmplitudeHalf;

        var sineWaveWaveLengthHalf = (sineWave.MaxWavelength - sineWave.MinWavelength) / 2f;
        sineWave.WaveLength = (sineWave.MinWavelength + sineWaveWaveLengthHalf) + wanderDirection.y * sineWaveWaveLengthHalf;
    }
}
