using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour {

    //UI
    //Health
    public Text player1HealthText;
    public Text player2HealthText;
    public Image healthSliderP1;
    public Image healthSliderP2;

    //Slow Motion
    public float Matrix;
       

    //Shield
    public Image shieldSliderP1;
    public Image shieldSliderP2;


    public GameObject player1;
    public GameObject player2;
    public float player1Health;
    public float player2Health;
    public float player1Shield;
    public float player2Shield;
    public float maxShield;

    //Load Scene
    public bool SceneOver = false;
    float currentTimeToReload;
    public float timeToReload;
    public string sceneToLoad;

    //Death ScreenShake
    public float shakeAmount;
    public float lenght;
    bool shaked = false;

    public GameObject mainCamera;

    // Use this for initialization
    void Start () {

        SceneOver = false;
    }
	
	// Update is called once per frame
	void Update () {
        player1Health = player1.GetComponent<PlayerController>().playerHealth;
        player2Health = player2.GetComponent<PlayerController>().playerHealth;

        player1Shield = player1.GetComponent<PlayerController>().currentShield;
        player2Shield = player2.GetComponent<PlayerController>().currentShield;

        maxShield = player1.GetComponent<PlayerController>().shieldedMax;

        //player1HealthText.text = "Player 1: " + player1Health.ToString();
        //player2HealthText.text = "Player 2: " + player2Health.ToString();


        //healthSliderP1.fillAmount = player1Health / 3.0f;
        //healthSliderP2.fillAmount = player2Health / 3.0f;

        //shieldSliderP1.fillAmount = player1Shield / maxShield;
        //shieldSliderP2.fillAmount = player2Shield / maxShield;

        /*
        Vector2 posPlayer1 = player1.transform.position;
        Vector2 posPlayer2 = player2.transform.position;
        Vector2 viewportPointPlayer1 = Camera.main.WorldToViewportPoint(posPlayer1);
        Vector2 viewportPointPlayer2 = Camera.main.WorldToViewportPoint(posPlayer2);
        */

        //Set bars to player position
        /*
        healthSliderP1.rectTransform.anchorMin = viewportPointPlayer1;
        healthSliderP1.rectTransform.anchorMax = viewportPointPlayer1;

        healthSliderP2.rectTransform.anchorMin = viewportPointPlayer2;
        healthSliderP2.rectTransform.anchorMax = viewportPointPlayer2;

        shieldSliderP1.rectTransform.anchorMin = viewportPointPlayer1;
        shieldSliderP1.rectTransform.anchorMax = viewportPointPlayer1;

        shieldSliderP2.rectTransform.anchorMin = viewportPointPlayer2;
        shieldSliderP2.rectTransform.anchorMax = viewportPointPlayer2;

    */







        if (player1Health <= 0 || player2Health <= 0)
        {
            deactivateUI();
            currentTimeToReload += Time.deltaTime;
            SceneOver = true;
            
            //mainCamera.GetComponent<ScreenShake>().ShakeScreen(shakeAmount, lenght);



            
            if (currentTimeToReload > timeToReload)
            {
                SceneManager.LoadScene(sceneToLoad);
            }





        }
        
            
    }

    void screenShake()
    {
        //Debug.Log("Calling shake");
        
        shaked = true;
        

    }
    void deactivateUI()
    {
        /*
        healthSliderP1.fillAmount = 0;
        healthSliderP2.fillAmount = 0;

        shieldSliderP1.fillAmount = 0;
        shieldSliderP2.fillAmount = 0;
        */
    }



    
}
