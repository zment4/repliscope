using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour {
    TextMesh textMesh;
    public bool DestroyWhenEnded = true;

	// Use this for initialization
	void Awake () {
        textMesh = GetComponent<TextMesh>();

        if (GameManager.HasInstance)
            textMesh.text = GameManager.Instance.CurrentScore.ToString("0000");
    }

    // Update is called once per frame
    void Update () {
        if (GameManager.Instance.HasGameEnded)
        {
            if (DestroyWhenEnded) Destroy(gameObject);
            return;
        }

        textMesh.text = GameManager.Instance.CurrentScore.ToString("0000");
	}
}
