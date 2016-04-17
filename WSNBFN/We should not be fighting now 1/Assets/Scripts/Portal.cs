using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

    public GameObject PortalExit;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<PlayerController>().outOfTeleporter == true)
        //{
            //other.GetComponent<PlayerController>().outOfTeleporter = false;
            //if (other.GetComponent<PlayerController>().teleported == false)
            //{
            //other.GetComponent<PlayerController>().teleported = true;
            other.transform.position = PortalExit.transform.position;

            //}
            //if (other.GetComponent<PlayerController>().teleported == true)
            //{


            //}

            }
            





        
    
    /*void OnTriggerExit (Collider other)
    {
        other.GetComponent<PlayerController>().outOfTeleporter = false;
        if (other.GetComponent<PlayerController>().outOfTeleporter == false)
        {
            other.GetComponent<PlayerController>().outOfTeleporter = true;
        }
        
    }*/
}
