using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author(s): Jackson, Katherine
//Updated: 05/05/24
//This script simulates bouyancy physics of any object interacting with it similar to water and runs on the physics timer. (Water physics)

[RequireComponent(typeof(Rigidbody))]
public class Buoyancy : MonoBehaviour
{
    public Transform[] floaters;

    [SerializeField] private float underWaterDrag = 1.5f;
    [SerializeField] private float underWaterAngularDrag = 1f;

    [SerializeField] private float airDrag = 0.05f;
    [SerializeField] private float airAngularDrag = 0.05f;

    [SerializeField] private float floatingPower = 40f;
    [SerializeField] private float waterHeight = -3.5f;

    OceanManager oceanManager;

    Rigidbody m_Rigidbody;

    int floatersUnderwater;
    bool underwater;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        oceanManager = FindObjectOfType<OceanManager>();
    }

    void FixedUpdate()
    {
        floatersUnderwater = 0;
        for (int i = 0; i < floaters.Length; i++)
        {
            float difference = transform.position.y - waterHeight;

            //Was going to use floater position to get the height of the water at the floater's pos but it requires
            //reworking the entire WaterShader graph. Which I do not want to do - KJ
            //float difference = floaters[i].position.y - oceanManager.WaterHeightAtPosition(floaters[i].position);

            if (difference < 0)
            {
                m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), floaters[i].position, ForceMode.Force);
                floatersUnderwater += 1;
                if (!underwater)
                {
                    underwater = true;
                    SwitchState(true);
                }
            }
        }

        if (underwater && floatersUnderwater == 0)
        {
            underwater = false;
            SwitchState(false);
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
