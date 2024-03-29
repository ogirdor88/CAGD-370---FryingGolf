using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //target is the golf ball
    [SerializeField]
    private Transform target;

    //offset is the distance between the camera and the folg ball
    private Vector3 offset;

    [SerializeField]
    private float rotateSpeed;

    private void Awake()
    {
        //get the offset from the camera and the ball
        offset = target.position - transform.position;    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
         * first attempt at having the camera rotate with the mouse movement
         * {
            //get the x position of the mouse and rotate the golf ball
            float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
            target.Rotate(0, horizontal, 0);

            float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
            target.Rotate(vertical, 0, 0);

            //move the camer based on the current rotation of the target and the original offset
            float desiredYAngle = target.eulerAngles.y;

            float desiredXAngle = target.eulerAngles.x;

            Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

            transform.position = target.position - (rotation * offset);
        }*/

        //move the camera to follow the player with the offset
        transform.position = target.position - offset;
        //make the camera look at the player
        transform.LookAt(target);

    }
}
