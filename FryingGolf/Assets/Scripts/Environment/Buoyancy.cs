using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author(s): Jackson, Katherine
//Updated: 04/15/24
//This script simulates bouyancy physics of any object interacting with it similar to water and runs on the physics timer. (Water physics)

[RequireComponent(typeof(Rigidbody))]
public class Buoyancy : MonoBehaviour
{
    [SerializeField] private float underWaterDrag = 3f;
    [SerializeField] private float underWaterAngularDrag = 1f;

    [SerializeField] private float airDrag = 0f;
    [SerializeField] private float airAngularDrag = 0.05f;

    [SerializeField] private float floatingPower = 40f;
    [SerializeField] private float waterHeight = -3.5f;

    Rigidbody m_Rigidbody;

    bool underwater;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float difference = transform.position.y - waterHeight;

        if (difference < 0)
        {
            m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);
            if (!underwater)
            {
                underwater = true;
                SwitchState(true);
            }
            else if (underwater)
            {
                underwater = false;
                SwitchState(false);
            }
        }
    }

    private void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            m_Rigidbody.drag = underWaterDrag;
            m_Rigidbody.angularDrag = underWaterAngularDrag;
        }
        else
        {
            m_Rigidbody.drag = airDrag;
            m_Rigidbody.angularDrag = airAngularDrag;
        }
    }
}
