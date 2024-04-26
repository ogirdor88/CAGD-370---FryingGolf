using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author(s): Jackson, Katherine
//Updated: 04/26/24
//This script sets the isTrigger component attached to the GameObject to true upon start.

public class Egg : MonoBehaviour
{
    BoxCollider m_boxCollider;

    private void Start()
    {
        //Fetch GameObject's collider
        m_boxCollider = GetComponent<BoxCollider>();
        //Sets the Collider's isTrigger to true
        m_boxCollider.isTrigger = true;
        //Output whether the Collider is a trigger type Collider or not
        Debug.Log("Trigger On : " + m_boxCollider.isTrigger);
    }
}
