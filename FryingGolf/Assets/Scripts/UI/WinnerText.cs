using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinnerText : MonoBehaviour
{
    //This script is planned for when the player 
    // Start is called before the first frame update
    private Text winnerText;
    public GameObject Goal;
    private int goal;

    void Start()
    {
        SetCountText();
        //Try 3 

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag=="Goalcheck")
        {
            SetCountText();
            print("Text winner appears");
            winnerText.text = "GOAL";
            //Heres comes test 1 
            //Test 1 :Failed No info on the text
            //Maybe changing the gameObject.tag might fix it maybe I Dunno 
            //That did not work wooo
            
        }
    }
    void Update()
    {
        
    }
    private void SetCountText()
    {
        winnerText.text = "goal" + goal.ToString();

    }
}
