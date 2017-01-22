using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public static bool HasInstance { get { return Instance != null; } }

    public PlayerHealth PlayerHealth;
    public SineWaveWanderer LeftWanderer;
    public SineWaveWanderer RightWanderer;

    public GameObject EnableOnEnd;

    float startTime;

	// Use this for initialization
	void Awake () {
		if (Instance)
        {
            DestroyImmediate(gameObject);
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

    public float CurrentScore;
    public bool HasGameEnded;

    private void Update()
    {
        if (HasGameEnded) return;

        CurrentScore += Time.deltaTime * (1f + PlayerHealth.CurrentHealth);

        if (PlayerHealth.CurrentHealth <= 0f)
        {
            EndGame();
        }

        LeftWanderer.Speed = RightWanderer.Speed = (CurrentScore / 100f) / 4f + (CurrentScore / 100f) * PlayerHealth.CurrentHealth;
    }

    private void EndGame()
    {
        HasGameEnded = true;

        if (EnableOnEnd) EnableOnEnd.SetActive(true);
    }

    public static bool AnyKeyDown()
    {
        if (Input.anyKeyDown) return true;

        for (int j = 1; j <= 4; j++)
        {
            for (int i = 0; i < 20; i++)
            {
                if (Input.GetKeyDown("joystick " + j + " button " + i))
                    return true;
            }
        }

        return false;
    }
}
