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
    public Transform respawnPoint;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Debug.Log("You are about to drown.");
            StartCoroutine(WaterTimer());
        }
        if (other.gameObject.tag == "DeathZone")
        {
            player.transform.position = respawnPoint.transform.position;
            player.GetComponent<LineForce>().StopBall();
            Debug.Log("You have died.");
        }
    }

    private IEnumerator WaterTimer()
    {
        yield return new WaitForSeconds(4f);
        Debug.Log("You drowned.");
        player.transform.position = respawnPoint.transform.position;
        player.GetComponent<LineForce>().StopBall();
    }
}
