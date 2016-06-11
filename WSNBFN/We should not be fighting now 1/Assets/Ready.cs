using UnityEngine;
using System.Collections;

public class Ready : MonoBehaviour
{

    public GameObject TextSprite;
    SpriteRenderer TextRenderer;
    Color InitialColor;
    public Color ActiveText;
    public bool PlayerReady = false;

    // Update is called once per frame


    void Start()
    {
        TextRenderer = TextSprite.GetComponent<SpriteRenderer>();
        InitialColor = TextRenderer.color;
    }
    void Update()
    {

        if (PlayerReady)
        {
            TextRenderer.color = ActiveText;
        }
        else
        {
            TextRenderer.color = InitialColor;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerReady = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerReady = false;
        }




    }
}