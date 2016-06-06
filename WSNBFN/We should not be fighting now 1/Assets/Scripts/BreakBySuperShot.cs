﻿using UnityEngine;
using System.Collections;

public class BreakBySuperShot : MonoBehaviour {

    public GameObject BreakableParticles;
    public GameObject Brother;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)

    {

        
        Vector3 instantiateParticles = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        
        if (other.tag == "SuperShot")
        {


            Instantiate(BreakableParticles, instantiateParticles, gameObject.transform.rotation);
            Destroy(gameObject);
            Destroy(Brother);
           
            

           
        }
    }
}
