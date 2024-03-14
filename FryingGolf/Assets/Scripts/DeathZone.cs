using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Author(s): Jackson, Katherine
//Updated: 03/14/24
//This script detects collision with any object and destroys it

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
