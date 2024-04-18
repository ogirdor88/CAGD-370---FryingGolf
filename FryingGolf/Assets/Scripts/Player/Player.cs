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
    public GameObject golfBall;

    private bool isBallIdle;
    //private float v = 2f;
    private float offset = 2f;

    //private float ballTransform = golfBall.GetComponent<Transform>();

    private void Awake()
    {
        isBallIdle = true;
    }

    private void Start()
    {
        fryingPan.SetActive(true);
    }

    private void Update()
    {

        //fryingPan.transform.position = golfBall.position + offset;

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
