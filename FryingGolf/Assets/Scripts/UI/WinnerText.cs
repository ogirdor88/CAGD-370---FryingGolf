using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinnerText : MonoBehaviour
{
    //This script is planned for when the player 
    // Start is called before the first frame update
   //:Thou author :Fernando Uribe-Hernandez
   //:Date :He forgot but its probably 3/14/24?
   //:Description:This is when the player interacts with the goal  they will activate the text that will tell them they have cleared the level and the 
   //scene is changing
    public GameObject Goal;
    private int goal;
    [SerializeField]
    public Text winnerText;
    public Text SceneChangeText;
    void Start()
    {
        winnerText.enabled = false;
        //Try 3 
        SceneChangeText.enabled = false;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            winnerText.enabled=true;
            //Ok so the text does turn out to be enabled but it doesn't disable 
            SceneChangeText.enabled = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            winnerText.enabled = false;
            SceneChangeText.enabled = false;
        }
    }
    void Update()
    {
        //Fernandos Idiotic report 1 3/18/24: I got a new laptop 
        //Spent two whole days setting up github and unity again .....cause for some reason it would show up a blank screen 
        //Now it works and you can see im writing here 
        //I did get a warning beforehand but I ignored it cause...I dunno
    }
    
}
