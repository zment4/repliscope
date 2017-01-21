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

        wanderTarget = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        wanderPosition = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        wanderDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)); ;

        ApplyWandererPosition();
    }

    // Update is called once per frame
    void Update ()
    {
        var newDir = wanderTarget - wanderPosition;
        wanderDirection = Vector3.Lerp(wanderDirection, newDir, Speed * Time.deltaTime);

        wanderPosition += wanderDirection.normalized * Time.deltaTime * Speed;

        if ((wanderPosition - wanderTarget).magnitude < 0.1f)
        {
            wanderTarget = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
        }

        ApplyWandererPosition();
    }

    private void ApplyWandererPosition()
    {
        var sineWaveAmplitudeHalf = (sineWave.MaxAmplitude - sineWave.MinAmplitude) / 2f;
        sineWave.Amplitude = (sineWave.MinAmplitude + sineWaveAmplitudeHalf) + wanderPosition.x * sineWaveAmplitudeHalf;

        var sineWaveWaveLengthHalf = (sineWave.MaxWavelength - sineWave.MinWavelength) / 2f;
        sineWave.WaveLength = (sineWave.MinWavelength + sineWaveWaveLengthHalf) + wanderPosition.y * sineWaveWaveLengthHalf;
    }
}
