using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float MaxHealth = 1f;
    public float CurrentHealth = 0.5f;
    public float HealthSpeed = 1f;

    public SineWaveColorCompare LeftSineWaveColorCompare;
    public SineWaveColorCompare RightSineWaveColorCompare;

    public float Distance;

    private HealthSlider healthSlider;

    void Awake()
    {
        healthSlider = GetComponent<HealthSlider>();
    }

    private void Update()
    {
        if (GameManager.Instance.HasGameEnded) return;

        float distance = (LeftSineWaveColorCompare.DistanceNormalized + RightSineWaveColorCompare.DistanceNormalized) - 0.5f;
        Distance = distance;

        CurrentHealth -= distance * Time.deltaTime * HealthSpeed;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

        healthSlider.Position = CurrentHealth * healthSlider.Height;
    }
}
