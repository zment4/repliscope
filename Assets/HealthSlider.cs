using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSlider : MonoBehaviour {
    public GameObject HealthKnob;
    public float Height;
    public float Position;

	// Update is called once per frame
	void Update () {
        if (!HealthKnob) return;

        transform.localScale = new Vector3(transform.localScale.x, Height, transform.localScale.z);
        HealthKnob.transform.position = new Vector3(transform.position.x, Position, transform.position.z);
    }
}
