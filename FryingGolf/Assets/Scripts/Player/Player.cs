using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

//Author(s): Jackson, Katherine
//Updated: 03/14/24
//This script handles interactions with other objects and the attached GameObject.

public class Player : MonoBehaviour
{
    public GameObject fryingPan;
    public Transform golfBall;

    private bool isBallIdle;
    //private float v = 2f;
    //private float offset = 2f;

    private Vector3 offset;

    //private float ballTransform = golfBall.GetComponent<Transform>();

    private void Awake()
    {
        isBallIdle = true;
        fryingPan.SetActive(true);
        offset = golfBall.position - fryingPan.transform.position;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //gets LineForce _isIdle bool state and sets isBallIdle equal to it
        isBallIdle = golfBall.GetComponent<LineForce>()._isIdle;

        //moves the fryingPan GameObject to the location of the golfBall transform at a distance, an offset
        fryingPan.transform.position = golfBall.position - offset;

        if (isBallIdle == false)
        {
            fryingPan.SetActive(false);
        }
        
        if (isBallIdle == true) 
        {
            fryingPan.SetActive(true);
        }
    }
}
