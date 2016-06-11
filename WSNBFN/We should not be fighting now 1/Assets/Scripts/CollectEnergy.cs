using UnityEngine;
using System.Collections;

public class CollectEnergy : MonoBehaviour {

    

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
            if (other.GetComponent<PlayerController>().canSuperShoot == true)
            {
                return;
            }

            if (other.GetComponent<PlayerController>().canSuperShoot == false)
            {


                Destroy(gameObject);
                other.GetComponent<PlayerController>().canSuperShoot = true;
            }
        }
    }
}
