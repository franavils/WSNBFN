using UnityEngine;
using System.Collections;

public class GiveDamage : MonoBehaviour {

    public int damageToGive;
    public GameObject thisPlayer;
    

    
    

    public GameObject particlesHitWall;
    public GameObject particlesHitPlayer;
    private GameObject cloneParticlesHitPlayer;
    

    public Transform originalObject;

    public Rigidbody rb;

    //ScreenShake
    public float shakeAmount;
    public float lenght;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        
        originalObject = this.gameObject.transform;
    }
	
	// Update is called once per frame
	void Update () {

        
	
	}

    
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log (other.gameObject.name);

        
        
        if (other.tag == "Player" && other.gameObject != thisPlayer)
        {
            //Destroy(gameObject);
            other.GetComponent<PlayerController>().loseHealth(damageToGive);
            other.GetComponent<PlayerController>().lastPlayerHittingThisPlayer = thisPlayer;
            FindObjectOfType<Camera>().GetComponent<ScreenShake>().ShakeScreen(shakeAmount, lenght);
            cloneParticlesHitPlayer = Instantiate(particlesHitPlayer, other.transform.position, other.transform.rotation) as GameObject;
            cloneParticlesHitPlayer.transform.parent = other.transform;
            
            
            
                       
        }
        
        

    }
}
