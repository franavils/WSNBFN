using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    // Use this for initialization
    public GameObject player1;
    public GameObject player2;

    public int player1Score;
    public int player2Score;

    void Awake ()
    {
        DontDestroyOnLoad(gameObject);
        


    }
	void Start () {

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<PlayerController>().playerScore = player1Score;
        player2.GetComponent<PlayerController>().playerScore = player2Score;
    }
	
	// Update is called once per frame
	void Update () {

        player1Score = player1.GetComponent<PlayerController>().playerScore;
        player2Score = player2.GetComponent<PlayerController>().playerScore;
    }

    void OnLevelWasLoaded()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<PlayerController>().playerScore = player1Score;
        player2.GetComponent<PlayerController>().playerScore = player2Score;
    }
}
