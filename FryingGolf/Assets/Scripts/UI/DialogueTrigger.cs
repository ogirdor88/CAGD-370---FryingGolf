using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{//Author(s):  Uribe-Hernandez, Fernando
 //Updated: 04/17/24
 //This script manages dialogue trigger boxes

    // Start is called before the first frame update
    public GameObject Dialogue;
    public GameObject Player;
    public GameObject DialogueJr;
    public float time = 2f;
    void Start()
    {
        Dialogue.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag=="Player")
        {
            
            Dialogue.SetActive(true);
            //ok so after two seconds the ball can start controlling if they spawn in 
            Invoke("disapear", time);
            Invoke("disapear2", time);


        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        Dialogue.SetActive(false);
       DialogueJr.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void disapear()
    {
        Dialogue.SetActive(false);
    }
    public void disapear2()
    {
        DialogueJr.SetActive(false);
    }
}
