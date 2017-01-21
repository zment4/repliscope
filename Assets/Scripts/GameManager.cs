using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public PlayerHealth PlayerHealth;
    public SineWaveWanderer LeftWanderer;
    public SineWaveWanderer RightWanderer;

    float startTime;

	// Use this for initialization
	void Awake () {
		if (Instance)
        {
            DestroyImmediate(this);
            Debug.LogWarning("Tried to create another singleton instance!");
            return;
        }

        Instance = this;

        startTime = Time.time;
	}

    private void OnDestroy()
    {
        Instance = null;
    }

    public int CurrentScore;
    public bool HasGameEnded;

    private void Update()
    {
        if (HasGameEnded) return;

        CurrentScore = Mathf.RoundToInt(Time.time - startTime);

        if (PlayerHealth && PlayerHealth.CurrentHealth <= 0f)
        {
            EndGame();
        }

        LeftWanderer.Speed = RightWanderer.Speed = CurrentScore / 100f;
    }

    private void EndGame()
    {
        HasGameEnded = true;
    }
}
