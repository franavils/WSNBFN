using UnityEngine;
using System.Collections;

public class Teleporting : MonoBehaviour
{

    public bool Teleported;
    public bool Vertical;

    // Use this for initialization
    void Start()
    {
        Teleported = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Teleported = other.GetComponent<BulletScript>().teleported;
            if (Teleported)
            {
                return;
            }

            if (Vertical)
            {
                other.GetComponent<BulletScript>().teleported = true;
                other.transform.position = new Vector3(-other.transform.position.x, other.transform.position.y, other.transform.position.z);
            } else if (Vertical == false)
            {
                other.GetComponent<BulletScript>().teleported = true;
                other.transform.position = new Vector3(other.transform.position.x, -other.transform.position.y, other.transform.position.z);
            }

        }
        if (other.tag == "Player")
        {


            Teleported = other.GetComponent<PlayerController>().teleported;
            if (Teleported)
            {
                return;
            }
            if (Vertical)
            {
                other.GetComponent<PlayerController>().teleported = true;
                other.transform.position = new Vector3(-other.transform.position.x, other.transform.position.y, other.transform.position.z);
            }
            else if (Vertical == false)
            {
                other.GetComponent<PlayerController>().teleported = true;
                other.transform.position = new Vector3(other.transform.position.x, -other.transform.position.y, other.transform.position.z);
            }
        }




    }


}

 
