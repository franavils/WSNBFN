using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

    public float shakeTimer;
    public float shakeAmount;
    

    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void ShakeScreen ( float ShakePwr, float ShakeDur)
    {
        shakeAmount = ShakePwr;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", ShakeDur);
    }

    void BeginShake ()
    {
        if (shakeAmount > 0)
        {
            //Debug.Log("Shaking!");
            Vector3 originalCameraPosition = transform.position;

            float shakeAmountX = Random.Range(-1.0f, 1.0f) * shakeAmount;
            float shakeAmountY = Random.Range (-1.0f, 1.0f) * shakeAmount;

            //Debug.Log(shakeAmountX);
            //Debug.Log(shakeAmountY);
            originalCameraPosition.x = shakeAmountX;
            originalCameraPosition.y = shakeAmountY;
            originalCameraPosition.z = 0f;

            transform.localPosition = originalCameraPosition;


        }
    }

    void StopShake()
    {
        //Debug.Log("Cancelling Screen Shake");
        CancelInvoke("BeginShake");
        transform.localPosition = Vector3.zero;
    }
}
