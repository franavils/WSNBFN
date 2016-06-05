using UnityEngine;
using System.Collections;

public class PickupRotation : MonoBehaviour {

    public float RotationSpeed;
    float currentXRotation;
    Transform t;

	// Use this for initialization
	void Start () {

        t = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        currentXRotation = t.rotation.x;
        t.Rotate(0, currentXRotation + RotationSpeed, 0);
	}
}
