using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    //Movement
    public float speed = 10;
    public bool teleported = false;
    public bool outOfTeleporter = true;

    //Stunned
    public bool stunned = false;
    public float stunnedDuration;
    public float _stunnedTime;
    public float StunnedShakeAmount;
    public float RotationShakeAmount;
    public GameObject StunnedParticles;
    

    //Shooting
    public GameObject bullet;
    float originalShootDelay;
    public float shootDelay = 0.1f;
    private bool canShoot = true;
    public Color bulletColour;
    public Color bulletLightColour;
    public float stray;

    //Controller
    public string leftStickHorizontal = "Horizontal_P1";
    public string leftStickVertical = "Vertical_P1";
    public string rightStickHorizontal = "HorizontalR_P1";
    public string rightStickVertical = "VerticalR_P1";
    //public string leftTrigger= "LeftTrigger_P1";
    public string leftShoulder = "LeftShoulder_P1";
    public string rightShoulder = "RightShoulder_P1";

    //Energy
    public int maxPlayerEnergy;
    public int playerEnergy;

    //Health
    public int maxPlayerHealth;
    public float playerHealth;
    public GameObject playerLife1;
    public GameObject playerLife2;
    public GameObject playerLife3;
    public int damageToGet;

    //Death
    public GameObject deathParticles;
    public GameObject deathParticlesJuice;
    public AudioSource BeforeDeath;
    public float DeathSpin;
    public float DeathPush;
    public float CurrentTimeToDie;
    public float TimeToDie;
    

    //Special:
    //Shield
    public GameObject shield;
    public bool shielded= false;
    public GameObject cloneShield;
    public float shieldedMax = 5.0f;
    public float currentShield;
    public float fixTimeToRealodSHiedl = 3.0f;
    public float timeBeginReloadShield;
    public bool shieldExhausted = false;

    //Super Shot
    public GameObject SuperShot;
    public GameObject SuperShotClone;
    public GameObject pickupInShip;

    public bool canSuperShoot;
    public bool SuperShotOn;
    public float SuperShotLifeTime;
    public float SuperShotCurrentLifeTime;

    //Score
    public int playerScore = 0;
    public GameObject scoreManager;
    public string thisPlayerName = "player1Score";
    

    public GameObject thisPlayer;
    public GameObject lastPlayerHittingThisPlayer;
    public GameObject playerKillingThisPlayer;
    public Renderer rend;
    public GameObject shipModel;



    bool dead = false;


    Rigidbody rb;

    void Awake()
    {
        
    }

    void Start()
    {

        originalShootDelay = shootDelay;
        currentShield = shieldedMax;


        thisPlayer = this.gameObject;

        
        playerEnergy = 0;
        maxPlayerEnergy = 100;

        timeBeginReloadShield = fixTimeToRealodSHiedl;


        rb = GetComponent<Rigidbody>();
        canShoot = true;
        canSuperShoot = false;
        
    }


    void Update()
    {
        
        //Stun
        if (stunned)
        {
            //Debug.Log("Hola");
            _stunnedTime += Time.deltaTime;

            if (_stunnedTime >= stunnedDuration)
            {
                StunnedParticles.SetActive(false);
                shootDelay = originalShootDelay;
                _stunnedTime = 0;
                stunned = false;
                return;
                
            }

            shootDelay = originalShootDelay * 4;
            StunnedParticles.SetActive(true);
            Quaternion StunnedParticlesRotationInitial = StunnedParticles.transform.rotation;

            Vector3 originalPlayerPosition = transform.position;
            Quaternion originalPlayerRotation = transform.rotation;
            float shakeAmountX = Random.Range(-1.0f, 1.0f) * StunnedShakeAmount;
            float shakeAmountY = Random.Range(-1.0f, 1.0f) * StunnedShakeAmount;


            float rotationAmountZ = Random.Range(-1.0f, 1.0f) * RotationShakeAmount;


            originalPlayerPosition.x += shakeAmountX;
            originalPlayerPosition.y += shakeAmountY;
            originalPlayerPosition.z = 0f;

            originalPlayerRotation.x += 0;
            originalPlayerRotation.y += 0;
            originalPlayerRotation.z += rotationAmountZ;

            transform.localPosition = originalPlayerPosition;
            transform.localRotation = originalPlayerRotation;
            StunnedParticles.transform.rotation = StunnedParticlesRotationInitial;
            if (canShoot)
            {
                float randomNumberZ = Random.Range(-stray, stray);

                bullet.GetComponent<GiveDamage>().thisPlayer = thisPlayer;
                GameObject bulletClone = Instantiate(bullet, thisPlayer.transform.position, thisPlayer.transform.rotation) as GameObject;
                bulletClone.transform.Rotate(0.0f, 0.0f, randomNumberZ);



                canShoot = false;
                Invoke("ResetShot", shootDelay);
            }

            
        }
        


              
        

        if (canSuperShoot)
        {
            pickupInShip.SetActive(true);
        } else
        {
            pickupInShip.SetActive(false);
        }

        //Destroy Super Shot
        if (SuperShotOn)
        {
            SuperShotCurrentLifeTime += Time.deltaTime;
            if (SuperShotCurrentLifeTime >= SuperShotLifeTime)
            {
                Destroy(SuperShotClone);
                SuperShotOn = false;
                SuperShotCurrentLifeTime = 0;
            }
        }

        //Shield
        if (timeBeginReloadShield <= 0)
        {
            shieldExhausted = false;
        }
        if (Input.GetButtonDown(leftShoulder) && currentShield > 0)
        {

            Shield();



        }
        if (Input.GetButtonUp(leftShoulder))
        {
            Unshield();

        }

        if (shielded)
        {
            thisPlayer.tag = "Environment";
            currentShield -= Time.deltaTime;
        } else
        {
            
            
            if (currentShield <= shieldedMax && shieldExhausted != true)
            {
                
                currentShield += Time.deltaTime/6;
                if (currentShield > 0)
                {
                    timeBeginReloadShield = fixTimeToRealodSHiedl;
                }
                
            }
            
        }

        if (currentShield <= 0)
        {
            
            Unshield();
            timeBeginReloadShield -= Time.deltaTime;
            shieldExhausted = true;

            
        }


        
        

        //Health
        if (playerHealth == 3)
        {
            playerLife1.SetActive(true);
            playerLife2.SetActive(true);
            playerLife3.SetActive(true);
        }  if (playerHealth == 2) {
                        
                playerLife1.SetActive(true);
                playerLife2.SetActive(true);
                playerLife3.SetActive(false);
            }  if (playerHealth == 1)
            {

                
                    playerLife1.SetActive(true);
                    playerLife2.SetActive(false);
                    playerLife3.SetActive(false);
                }
        if (playerHealth == 0)
        {


            playerLife1.SetActive(false);
            playerLife2.SetActive(false);
            playerLife3.SetActive(false);
        }



        //Death 
        if (dead)
        {
            
        } else if (playerHealth > 0)
        {
            loseHealth(damageToGet);
        }
        else
        {
             
            CurrentTimeToDie += Time.deltaTime;

            BeforeDeath.pl
            transform.Rotate(0, 0, DeathSpin);
            playerKillingThisPlayer = lastPlayerHittingThisPlayer;
            playerKillingThisPlayer.GetComponent<PlayerController>().playerScore += 1;
            StunnedParticles.SetActive(true);

                if (CurrentTimeToDie >= TimeToDie)
                {
                    death();
                }
        }



            //Twin stick shooting and rotating
            Vector3 shootDirection = new Vector3(Input.GetAxis(rightStickHorizontal), Input.GetAxis(rightStickVertical), 0);

            if (shootDirection.sqrMagnitude > 0.1f)
        {
           
            Vector2 stickDir = new Vector2(Input.GetAxis(rightStickHorizontal), Input.GetAxis(rightStickVertical));
            stickDir.Normalize();
            
            var angle = Mathf.Atan2(stickDir.x, stickDir.y) * Mathf.Rad2Deg;
            thisPlayer.transform.rotation = Quaternion.Euler(0, 0, -angle);


           

            //Shooting
            if (canShoot)
            {
                float randomNumberZ = Random.Range(-stray,stray);
                
                bullet.GetComponent<GiveDamage>().thisPlayer = thisPlayer;
                GameObject bulletClone = Instantiate(bullet,thisPlayer.transform.position, thisPlayer.transform.rotation) as GameObject;
                bulletClone.transform.Rotate(0.0f, 0.0f, randomNumberZ);
                

                
                canShoot = false;
                Invoke("ResetShot", shootDelay);
            }
            



        }
        //Super Shot

        if (canSuperShoot && Input.GetButton(rightShoulder))
        {
            SuperShotClone = Instantiate(SuperShot, thisPlayer.transform.position, thisPlayer.transform.rotation) as GameObject;
            canSuperShoot = false;
            SuperShotClone.GetComponentInChildren<SuperShot>().thisPlayer = thisPlayer;
            //SuperShot.GetComponentInChildren<GiveDamage>().thisPlayer = thisPlayer;
            SuperShotClone.transform.rotation = gameObject.transform.rotation;
            SuperShotOn = true;
        }




    }

    void FixedUpdate()
    {
        if (stunned)
        {
            Debug.Log("I can't move");
            return;
        }
        else if (stunned == false)
        {
            //Moving using force
            //Debug.Log("Moving again");
            float moveHorizontal = Input.GetAxis(leftStickHorizontal);

            float moveVertical = Input.GetAxis(leftStickVertical);



            rb.AddForce(moveHorizontal * speed, moveVertical * speed, 0);
        }

        


        




    }
    void ResetShot()
    {
        canShoot = true;
    }

    public void Shield()
    {
        cloneShield = Instantiate(shield, thisPlayer.transform.position,thisPlayer.transform.rotation) as GameObject;
        //Debug.Log("Shield!");
        cloneShield.transform.parent = thisPlayer.transform;
        shielded = true;


    }

    public void Unshield()
    {
        Destroy(cloneShield);
        shielded = false;
        thisPlayer.tag = "Player";

    }

   
    

    public void getEnergy(int energyToGet)
    {
        playerEnergy += energyToGet;
    }

    public void loseHealth(int damageToGet)
    {
        
        playerHealth -= damageToGet;

    }
    public void death()
    {


        dead = true;
        Instantiate(deathParticlesJuice, thisPlayer.transform.position,thisPlayer.transform.rotation);
        Instantiate(deathParticles, transform.position, transform.rotation);

        //Debug.Log(playerKillingThisPlayer.name + " score: " + playerKillingThisPlayer.GetComponent<PlayerController>().playerScore);


        gameObject.SetActive(false);
            //thisPlayer.GetComponent<Collider>().enabled = false;
            //rend = shipModel.GetComponent<Renderer>();
            //rend.enabled = false;
        
    }
}
