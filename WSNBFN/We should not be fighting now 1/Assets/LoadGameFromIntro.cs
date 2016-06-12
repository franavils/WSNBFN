using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameFromIntro : MonoBehaviour {

    public GameObject ReadyPlayer1;
    public GameObject ReadyPlayer2;

    bool Player1IsReady = false;
    bool Player2IsReady = false;

    public float TimeToLoadLevel;
    public float CurrentTimeToLoadLevel;

    public Text Countdown;

    public string sceneToLoad;

    // Use this for initialization
    void Start () {
        CurrentTimeToLoadLevel = TimeToLoadLevel;
    }
	
	// Update is called once per frame
	void Update () {
        Player1IsReady = ReadyPlayer1.GetComponent<Ready>().PlayerReady;
        Player2IsReady = ReadyPlayer2.GetComponent<Ready>().PlayerReady;

        if (CurrentTimeToLoadLevel > 3)
        {
            Countdown.text = " ";
        }
        if (CurrentTimeToLoadLevel < 3 && CurrentTimeToLoadLevel > 2)
        {
            Countdown.text = "3";
        }
        if (CurrentTimeToLoadLevel < 2 && CurrentTimeToLoadLevel > 1)
        {
            Countdown.text = "2";
        }
        if (CurrentTimeToLoadLevel < 1 && CurrentTimeToLoadLevel > 0.2)
        {
            Countdown.text = "1";
        }
        if (CurrentTimeToLoadLevel <= 0.2)
        {
            Countdown.text = "GO";
        }


        if (Player1IsReady == false || Player2IsReady == false)
        {
            CurrentTimeToLoadLevel = TimeToLoadLevel;
        }
            if (Player1IsReady && Player2IsReady)
        {
            CurrentTimeToLoadLevel -= Time.deltaTime;

            if (CurrentTimeToLoadLevel <= 0)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }

    }
}
