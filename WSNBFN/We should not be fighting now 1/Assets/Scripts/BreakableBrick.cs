using UnityEngine;
using System.Collections;

public class BreakableBrick : MonoBehaviour
{

    public GameObject BreakableParticles;

    public GameObject collectible;

    public bool hasAPickUp;


    public int random;
    public int maxRange;
    
    

    // Use this for initialization
    void Start()
    {

        int random = Random.Range(0, maxRange);
        //Debug.Log("I am number " + random);
        if (random == 1)
        {
            hasAPickUp = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)

    {
        Vector3 instantiateParticles = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        Quaternion collectibleCurrentRotation = collectible.GetComponent<Transform>().rotation;
        if (other.tag == "Bullet" || other.tag == "SuperShot")
        {

            //other.GetComponent<Animator>().SetTrigger("Enemy crashed");
            Destroy(gameObject);
            //Destroy(other.gameObject);
            Instantiate(BreakableParticles, instantiateParticles , collectibleCurrentRotation);

            if (hasAPickUp)
            {
                Instantiate(collectible, transform.position, collectibleCurrentRotation);
            }
            
            


        }
    }
}