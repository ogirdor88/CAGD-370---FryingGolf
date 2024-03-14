using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private PlayerControlls input;
    private float movespeed;

    private void Awake()
    {
        input = new PlayerControlls();
        input.Enable();
    }

}