using UnityEngine;
using System.Collections;

public class SuperShot : MonoBehaviour {

    public float timeToDestroy;
    float bulletTimeCounter;

    public int damageToGive;
    public GameObject thisPlayer;

    public GameObject particlesHitWall;
    public GameObject particlesHitPlayer;
    private GameObject cloneParticlesHitPlayer;

    //ScreenShake
    public float shakeAmount;
    public float lenght;

    public Transform originalObject;

    // Use this for initialization
    void Start () {
	
	}
	
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
        Debug.Log (other.gameObject.name);

        if (other.tag == "Environment")
        {

            Debug.Log("I am environment, be careful!");
            Instantiate(particlesHitWall, transform.position, transform.rotation);
            



        }

        if (other.tag == "Player" && other.gameObject != thisPlayer)
        {
            Destroy(gameObject);
            other.GetComponent<PlayerController>().loseHealth(damageToGive);
            other.GetComponent<PlayerController>().lastPlayerHittingThisPlayer = thisPlayer;
            FindObjectOfType<Camera>().GetComponent<ScreenShake>().ShakeScreen(shakeAmount, lenght);
            cloneParticlesHitPlayer = Instantiate(particlesHitPlayer, other.transform.position, other.transform.rotation) as GameObject;
            cloneParticlesHitPlayer.transform.parent = other.transform;







        }
    }
}
