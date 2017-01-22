using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnAnyKey : MonoBehaviour {
    public float InputDelay = 0.5f;
    float enabledTime;

    private void OnEnable()
    {
        enabledTime = Time.time;
    }

	// Update is called once per frame
	void Update () {
        if (Time.time - enabledTime > InputDelay && GameManager.AnyKeyDown())
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
