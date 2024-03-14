using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.DefaultInputActions;

public class BasicMovement : MonoBehaviour
{
    private PlayerControlls input;
    private float movespeed;
    private Vector3 currentPosition;

    private void Awake()
    {
        input = new PlayerControlls();
        input.Enable();
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = input.PlayerMove.Move.ReadValue<Vector2>();

        //apply the move vector to the player
        GetComponent<Rigidbody>().AddForce(new Vector3(moveVec.x, 0, moveVec.y) * 5f, ForceMode.Force);
    }

}