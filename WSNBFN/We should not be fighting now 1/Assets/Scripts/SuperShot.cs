using UnityEngine;
using System.Collections;

public class SuperShot : MonoBehaviour {

    public float timeToDestroy;
    float bulletTimeCounter;

    public int damageToGive;
    public GameObject thisPlayer;

    //public GameObject particlesHitWall;
    //public GameObject particlesHitPlayer;
    //private GameObject cloneParticlesHitPlayer;

    //ScreenShake
    //public float shakeAmount;
    //public float lenght;

    public Transform originalObject;

    
	
	// Update is called once per frame
	void Update () {
        bulletTimeCounter += Time.deltaTime;

        if (bulletTimeCounter >= timeToDestroy)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log (other.gameObject.name);

        

        if (other.tag == "Player" && other.gameObject != thisPlayer)
        {
            //Destroy(gameObject);
            //other.GetComponent<PlayerController>().loseHealth(damageToGive);
            other.GetComponent<PlayerController>().lastPlayerHittingThisPlayer = thisPlayer;
            other.GetComponent<PlayerController>().stunned = true;
            //FindObjectOfType<Camera>().GetComponent<ScreenShake>().ShakeScreen(shakeAmount, lenght);
            







        }
    }
}
