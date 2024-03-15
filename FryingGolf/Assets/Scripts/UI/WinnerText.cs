using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinnerText : MonoBehaviour
{
    //This script is planned for when the player 
    // Start is called before the first frame update
    public Text winnerText;
    public GameObject Goal;
    private int goal;

    void Start()
    {
        winnerText.enabled = false;
        //Try 3 

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Goalcheck")
        {
            winnerText.enabled=true;

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
