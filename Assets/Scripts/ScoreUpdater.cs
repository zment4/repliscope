using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour {
    TextMesh textMesh;

	// Use this for initialization
	void Awake () {
        textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.HasGameEnded) return;

        textMesh.text = GameManager.Instance.CurrentScore.ToString("0000");
	}
}
