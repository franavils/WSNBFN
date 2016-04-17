using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour
{

    public float speed = 100;
    Rigidbody rb;
    public Vector3 currentVelocity;

    public GameObject bulletDestroyedParticles;
    float bulletTimeCounter;
    public float timeToDestroy;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bulletTimeCounter = 0;
        currentVelocity = transform.up;




    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = currentVelocity * speed;

        bulletTimeCounter += Time.deltaTime;


        if (bulletTimeCounter >= timeToDestroy)
        {
            Instantiate(bulletDestroyedParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }



    }

    void FixedUpdate()
    {
        // Bullet bouncing
        RaycastHit hit;

        if (Physics.Raycast(transform.position, gameObject.GetComponent<BulletScript>().currentVelocity, out hit, 0.5f))
        {
            if (hit.collider.tag == "Environment")
            {

                gameObject.GetComponent<BulletScript>().currentVelocity = Vector3.Reflect(gameObject.GetComponent<BulletScript>().currentVelocity, hit.normal);

                float angle = Vector3.Angle(gameObject.GetComponent<BulletScript>().currentVelocity, hit.normal);


                transform.up = rb.gameObject.GetComponent<BulletScript>().currentVelocity;



            }

        }




    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log (other.gameObject.name);

        if (other.tag == "Environment")
        {


            //Instantiate(particlesHitWall, transform.position, transform.rotation);



        }
        if (other.tag == "BreakableObject")
        {
            Instantiate(bulletDestroyedParticles, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
}
