using UnityEngine;
using System.Collections;

public class TeleportingPreparing : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {

        
        Debug.Log("Someone is entering");
        other.GetComponent<PlayerController>().teleported = false;
        }
    }

}
