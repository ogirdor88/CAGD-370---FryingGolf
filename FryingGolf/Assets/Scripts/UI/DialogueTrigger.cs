using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{//Author(s):  Uribe-Hernandez, Fernando
 //Updated: 04/17/24
 //This script manages dialogue trigger boxes

    // Start is called before the first frame update
    public GameObject Dialogue;

    void Start()
    {
        Dialogue.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag=="Player")
        {
            Dialogue.SetActive(true);
            Invoke("disapear", 4f);
        }
    }
    private void OnTriggerExit(Collider other)
    {

        Dialogue.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void disapear()
    {
        Dialogue.SetActive(false);
    }
}
