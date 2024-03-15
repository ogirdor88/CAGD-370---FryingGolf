using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.DefaultInputActions;

/// <summary>
/// Rodrigo Lopez-Patino
/// 
/// set up a basic movement system and jump for testing
/// </summary>
public class BasicMovement : MonoBehaviour
{
    private PlayerControlls input;
    private float movespeed;
    private Vector3 currentPosition;

    private void Awake()
    {
        input = new PlayerControlls();
        input.PlayerMove.Enable();
    }

    private void FixedUpdate()
    {
        //get the vector2 data from the move action composite
        Vector2 moveVec = input.PlayerMove.Move.ReadValue<Vector2>();

        //apply the move vector to the player
        GetComponent<Rigidbody>().AddForce(new Vector3(moveVec.x, 0, moveVec.y) * 5f, ForceMode.Force);
    }
    
    public void Jump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.started)
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
}