using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public string SceneToLoad;
    public bool AutoLoad = false;
    public float AutoLoadDelay = 3f;

    float startTime;

    private void Awake()
    {
        if (AutoLoad) startTime = Time.time;
    }

	void Update () {
        if ((AutoLoad && Time.time - startTime > AutoLoadDelay) || GameManager.AnyKeyDown())
            SceneManager.LoadScene(SceneToLoad);
	}
}
