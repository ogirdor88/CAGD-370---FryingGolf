using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Author(s): Jackson, Katherine
//Updated: 03/14/24
//This script detects collision with the player and respawns the player.

public class DeathZone : MonoBehaviour
{
    public Transform player;
    public GameObject respawnPoint;
    public bool isWaterColliding;

    //private Rigidbody golfballRB;

    //private string waterCoroutine = WaterTimer();

    private void FixedUpdate()
    {
        if (isWaterColliding != true)
        {
            StopCoroutine(WaterTimer());
        }
    }

    //Once Golfball GameObject collides with another object, checks if the other GameObject's tag is "Water" or "DeathZone"
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Debug.Log("You are about to drown.");
            //Sets waterColliding boolean to true for WaterTimer to check if it is true or false
            isWaterColliding = true;
            //Starts IEnumerator WaterTimer which respawns player after a certain time if the waterColliding boolean is true
            StartCoroutine("WaterTimer");
            
        }
        //Immediately respawns the player
        if (other.gameObject.tag == "DeathZone")
        {
            player.transform.position = respawnPoint.transform.position;
            player.GetComponent<LineForce>().StopBall();
            Debug.Log("You have died.");
        }
    }

    //Once Golfball GameObject exits collision trigger with another object, no matter the object, sets the waterColliding boolean to false
    //This causes the WaterTimer to stop if the player is no longer touching the trigger object (Will later change)
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            isWaterColliding = false;
        }
        
    }

    private IEnumerator WaterTimer()
    {
        yield return new WaitForSeconds(4f);
        Debug.Log("Checking if in water...");
        if (isWaterColliding == true)
        {
            Debug.Log("You drowned.");
            player.transform.position = respawnPoint.transform.position;
            //player.GetComponent<LineForce>().StopBall();
            Debug.Log("Respawned.");
        }
        else
        {
            isWaterColliding = false;
        }
    }
}
