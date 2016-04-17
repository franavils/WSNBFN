using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

    public float shieldTimer = 4.0f;
    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       /* shieldTimer -= Time.deltaTime;
        if (shieldTimer <= 0)
        {
            Destroy(gameObject);
            GetComponentInParent<PlayerController>().shielded = false;
        }*/
	}
}
