using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author(s): Jackson, Katherine
//Updated: 03/14/24
//This script is a child of DeathZone parent class and is used to detect when the player has left the water and
//the Ienumerator WaterTimer coroutine inside of the parent class.

public class DeathWater : DeathZone
{
    /*public OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine("WaterTimer");
            Debug.Log("You stopped drowning.");
        }
    }*/
}
