using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    // Use this for initialization
    public GameObject player1;
    public GameObject player2;
    public AudioSource SoundTrack;

    public int player1Score;
    public int player2Score;

    // Show score
    public GameObject ScoreEmpty;

    public GameObject P1Diamond1;
    public GameObject P1Diamond2;
    public GameObject P1Diamond3;
    public GameObject P1Diamond4;

    public GameObject P2Diamond1;
    public GameObject P2Diamond2;
    public GameObject P2Diamond3;
    public GameObject P2Diamond4;

    public GameObject LevelManager;

    public bool SceneOver;
    public float WaitForUI;
    public float CurrentWaitForUI;

    void Awake ()
    {
        DontDestroyOnLoad(gameObject);

        LevelManager = GameObject.Find("LevelManager");


    }
	void Start () {

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        SceneOver = false;

        player1.GetComponent<PlayerController>().playerScore = player1Score;
        player2.GetComponent<PlayerController>().playerScore = player2Score;

        if (SoundTrack.isPlaying)
        {
            return;
        } else
        SoundTrack.Play();
    }
	
	// Update is called once per frame
	void Update () {

        player1Score = player1.GetComponent<PlayerController>().playerScore;
        player2Score = player2.GetComponent<PlayerController>().playerScore;

if (SceneOver == false)
        {
                    
        SceneOver = LevelManager.GetComponent<HealthManager>().SceneOver;

        }

        if (SceneOver)
        {
            CurrentWaitForUI += Time.deltaTime;
            if (CurrentWaitForUI >= WaitForUI)
            {
                ScoreEmpty.SetActive(true);
                if (player1Score == 0)
                {

                } else
                if (player1Score == 1)
                {
                    P1Diamond1.SetActive(true);
                }
                if (player1Score == 2)
                {
                    P1Diamond1.SetActive(true);
                    P1Diamond2.SetActive(true);
                }
                if (player1Score == 3)
                {
                    P1Diamond1.SetActive(true);
                    P1Diamond2.SetActive(true);
                    P1Diamond3.SetActive(true);
                }
                if (player1Score == 4)
                {
                    P1Diamond1.SetActive(true);
                    P1Diamond2.SetActive(true);
                    P1Diamond3.SetActive(true);
                    P1Diamond4.SetActive(true);
                }
                if (player2Score == 0)
                {

                } else
                if (player2Score == 1)
                {
                    P2Diamond1.SetActive(true);
                }
                if (player2Score == 2)
                {
                    P2Diamond1.SetActive(true);
                    P2Diamond2.SetActive(true);
                }
                if (player2Score == 3)
                {
                    P2Diamond1.SetActive(true);
                    P2Diamond2.SetActive(true);
                    P2Diamond3.SetActive(true);
                }
                if (player2Score == 4)
                {
                    P2Diamond1.SetActive(true);
                    P2Diamond2.SetActive(true);
                    P2Diamond3.SetActive(true);
                    P2Diamond4.SetActive(true);
                }

            }
        }
    }

    void OnLevelWasLoaded()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        Scene thisScene = SceneManager.GetActiveScene();

        SceneOver = false;
        CurrentWaitForUI = 0;

        if (thisScene.name != ("Intro") )
        {
            Debug.Log("This Scene is not intro and I should load the diamonds");
            P1Diamond1 = GameObject.Find("P1Diamond1");
            P1Diamond2 = GameObject.Find("P1Diamond2");
            P1Diamond3 = GameObject.Find("P1Diamond3");
            P1Diamond4 = GameObject.Find("P1Diamond4");

            P1Diamond1.SetActive(false);
            P1Diamond2.SetActive(false);
            P1Diamond3.SetActive(false);
            P1Diamond4.SetActive(false);

            P2Diamond1 = GameObject.Find("P2Diamond1");
            P2Diamond2 = GameObject.Find("P2Diamond2");
            P2Diamond3 = GameObject.Find("P2Diamond3");
            P2Diamond4 = GameObject.Find("P2Diamond4");

            P2Diamond1.SetActive(false);
            P2Diamond2.SetActive(false);
            P2Diamond3.SetActive(false);
            P2Diamond4.SetActive(false);

            ScoreEmpty = GameObject.Find("ScoreEmpty");
            ScoreEmpty.SetActive(false);
            

        }

    

        LevelManager = GameObject.Find("LevelManager");


        player1.GetComponent<PlayerController>().playerScore = player1Score;
        player2.GetComponent<PlayerController>().playerScore = player2Score;
    }
}
