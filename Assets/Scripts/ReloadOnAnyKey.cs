using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnAnyKey : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (GameManager.AnyKey())
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
