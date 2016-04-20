using UnityEngine;
using System.Collections;

public class BreakBySuperShot : MonoBehaviour {

    public GameObject BreakableParticles;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)

    {

        Debug.Log(other.name);
        Vector3 instantiateParticles = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        
        if (other.tag == "SuperShot")
        {


            Instantiate(BreakableParticles, instantiateParticles, gameObject.transform.rotation);
            Destroy(gameObject);
           
            

           
        }
    }
}
