using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{//Author(s): Uribe-Hernandez, Fernando, Jackson, Katherine
 //Updated: 04/24/24
 //This script manages dialogue trigger boxes.

    // Start is called before the first frame update
    public GameObject DialogueText;
    public GameObject Player;
    public GameObject DialogueCollider;
    public float time = 5f;
    void Start()
    {
        DialogueText.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag=="Player")
        {
            
            DialogueText.SetActive(true);
            //ok so after three seconds the ball can start controlling if they spawn in 
            Invoke("disapear", time);
            Invoke("disapear2", time);


        }
    }

    //This is being edited out because,
    //if the player exits the collider too quickly, then they will not be able to read the text.
    /*private void OnTriggerExit(Collider other)
    {
        
        DialogueText.SetActive(false);
        DialogueCollider.SetActive(false);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
    private void disapear()
    {
        DialogueText.SetActive(false);
    }
    public void disapear2()
    {
        DialogueCollider.SetActive(false);
    }
}
