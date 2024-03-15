using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WinnerText : MonoBehaviour
{
    //This script is planned for when the player 
    // Start is called before the first frame update
   
    public GameObject Goal;
    private int goal;
    [SerializeField]
    public Text winnerText;
    void Start()
    {
        winnerText.enabled = false;
        //Try 3 

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            winnerText.enabled=true;
            //Ok so the text does turn out to be enabled but it doesn't disable 
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
    void Update()
    {
        
    }
    
}
