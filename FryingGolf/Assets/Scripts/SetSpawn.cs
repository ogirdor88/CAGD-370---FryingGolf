using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author(s): Jackson, Katherine
//Updated: 03/14/24
//This script sets the standard position for the player to spawn at

public class SetSpawn : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
    }
}
