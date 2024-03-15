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
      

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            SetCountText();
            print("Text winner appears");
            winnerText.text = "GOAL";
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
