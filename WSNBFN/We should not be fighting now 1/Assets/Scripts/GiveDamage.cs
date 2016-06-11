using UnityEngine;
using System.Collections;

public class GiveDamage : MonoBehaviour {

    public int damageToGive;
    public GameObject thisPlayer;
    

    
    

    public GameObject particlesHitWall;
    public GameObject particlesHitPlayer;
    private GameObject cloneParticlesHitPlayer;

    public float RecoilFromBullet;
    

    public Transform originalObject;
    Vector3 CurrentDirection;

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

            CurrentDirection = rb.velocity;
            Destroy(gameObject);
            
            other.GetComponent<PlayerController>().loseHealth(damageToGive);
            other.GetComponent<PlayerController>().lastPlayerHittingThisPlayer = thisPlayer;
            FindObjectOfType<Camera>().GetComponent<ScreenShake>().ShakeScreen(shakeAmount, lenght);
           
            cloneParticlesHitPlayer = Instantiate(particlesHitPlayer, other.transform.position, other.transform.rotation) as GameObject;
            cloneParticlesHitPlayer.transform.parent = other.transform;


            if (other.GetComponent<PlayerController>().playerHealth == 0)
            {
                other.GetComponent<Rigidbody>().drag = 0;
                other.GetComponent<Rigidbody>().AddForce(CurrentDirection * RecoilFromBullet);
            } else

            other.GetComponent<Rigidbody>().AddForce(CurrentDirection * RecoilFromBullet);




        }
        
        

    }
}
